using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MusicShuffler
{
    /// <summary>
    /// Represents a library of songs.
    /// </summary>
    public class Library
    {
        protected List<Song> songs = new List<Song>();
        protected object syncRoot = new object();
        protected bool loaded = false;
        private Queue<FileInfo> loadQueue = new Queue<FileInfo>();
        private Dictionary<string, Song> previousLibrary = new Dictionary<string, Song>();

        public bool IsLoaded
        {
            get { lock (syncRoot) return loaded; }
        }

        /// <summary>
        /// Gets a collection of distinct genres.
        /// </summary>
        public ReadOnlyCollection<string> Genres
        {
            get
            {
                List<string> genres = new List<string>();

                lock (syncRoot)
                {
                    foreach (Song song in songs)
                    {
                        if (!genres.Contains(song.GenreName))
                            genres.Add(song.GenreName);
                    }
                }

                return genres.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets a collection of distinct artists.
        /// </summary>
        public ReadOnlyCollection<string> Artists
        {
            get
            {
                List<string> artists = new List<string>();

                lock (syncRoot)
                {
                    foreach (Song song in songs)
                    {
                        if (!artists.Contains(song.ArtistName))
                            artists.Add(song.ArtistName);
                    }
                }

                return artists.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets a list of songs contained in this Library
        /// </summary>
        public ReadOnlyCollection<Song> Songs
        {
            get { lock (syncRoot) return songs.AsReadOnly(); }
        }

        /// <summary>
        /// Adds a directory to the library
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="directoryName"></param>
        public void AddDirectory(string directoryName)
        {
            if (!Directory.Exists(directoryName))
                throw new DirectoryNotFoundException(directoryName);

            List<FileInfo> files = new List<FileInfo>();

            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryName);

                // Recurse the directory
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    try
                    {
                        // Add the sub directory
                        AddDirectory(subDirectory.FullName);
                    }
                    catch (Exception)
                    {
                    }
                }

                lock (syncRoot)
                {
                    // Go through the MP3 files in the directory
                    foreach (FileInfo file in directory.GetFiles("*.mp3"))
                    {
                        if (songs.Find(song => song.FileName == file.FullName) == null)
                        {

                            if (!loadQueue.Contains(file))
                                loadQueue.Enqueue(file);
                        }
                    }

                    if (loadQueue.Count > 0)
                        loaded = false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoadFromFile()
        {
            lock (syncRoot)
            {
                string libraryPath = Utils.GetLibraryPath();

                try
                {
                    List<Song> librarySongs =
                        XmlSerializationTool<List<Song>>.Load(libraryPath);

                    foreach (Song song in librarySongs)
                    {
                        if (song.LastModified == File.GetLastWriteTime(song.FileName))
                            previousLibrary.Add(song.FileName, song);
                    }
                }
                catch (Exception e)
                {
                    // TODO: Log the error
                }
            }
        }

        /// <summary>
        /// Saves the library so that it can be loaded fast upon next loading.
        /// </summary>
        public void Save()
        {
            lock (syncRoot)
            {
                string libraryPath = Utils.GetLibraryPath();

                try
                {
                    XmlSerializationTool<List<Song>>.Save(
                        songs, libraryPath);
                }
                catch (Exception e)
                {
                    // TODO: Log the error
                }
            }
        }

        /// <summary>
        /// Returns an <c>BackgroundWorker</c> which can be used for loading
        /// the library in background
        /// </summary>
        /// <returns></returns>
        public virtual BackgroundWorker GetBackgroundLoader()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += LoadAtBackground;

            return worker;
        }


        /// <summary>
        /// An event handler for BackgroundWorker.DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoadAtBackground(object sender, DoWorkEventArgs e)
        {
            lock (syncRoot)
            {
                LoadFromFile();
                BackgroundWorker worker = sender as BackgroundWorker;
                int done = 0;
                int total = loadQueue.Count;

                while (true)
                {
                    if (worker.CancellationPending)
                        return;

                    if (loadQueue.Count == 0)
                        break;

                    FileInfo file = loadQueue.Dequeue();

                    try
                    {
                        // Process the song
                        songs.Add(ProcessFile(file));
                        done++;

                        // Report of the progress
                        worker.ReportProgress(
                            (int)Math.Floor((double)done / (double)total * 100));
                    }
                    catch (Exception)
                    {
                    }
                }

                // Set the library as loaded
                loaded = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected Song ProcessFile(FileInfo file)
        {
            if (previousLibrary.ContainsKey(file.FullName))
                return previousLibrary[file.FullName];

            Song song = new Song();
            song.FileName = file.FullName;
            song.FileSize = file.Length;
            song.LastModified = file.LastWriteTime;

            // Load the metadata using TagLib
            TagLib.File tagFile = TagLib.File.Create(file.FullName);
            song.AlbumName = tagFile.Tag.Album;
            song.ArtistName = tagFile.Tag.FirstPerformer;
            song.Title = tagFile.Tag.Title;
            song.GenreName = tagFile.Tag.FirstGenre;
            song.Duration = tagFile.Properties.Duration;

            return song;
        }
    }
}
