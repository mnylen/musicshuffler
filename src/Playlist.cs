using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MusicShuffler
{
    /// <summary>
    /// Represents an playlist that can be shuffled.
    /// </summary>
    public class Playlist
    {
        private IEnumerable<Song> _availableSongs = new List<Song>();
        private List<Song> _songs = new List<Song>();
        private List<Song> _added = new List<Song>();

        /// <summary>
        /// Gets the list of songs in this playlist
        /// </summary>
        public ReadOnlyCollection<Song> Songs
        {
            get { return _songs.AsReadOnly(); }
        }

        /// <summary>
        /// Gets the list of songs manually added to the playlist
        /// </summary>
        public ReadOnlyCollection<Song> AddedSongs
        {
            get { return _added.AsReadOnly(); }
        }

        /// <summary>
        /// Gets or sets a list of songs that may be used for generating the
        /// playlist.
        /// </summary>
        public IEnumerable<Song> Library
        {
            get { return _availableSongs; }
            set { _availableSongs = value; }
        }

        /// <summary>
        /// Gets the total file size, in bytes, of this playlist.
        /// </summary>
        public long TotalFileSize
        {
            get { return _songs.GetTotalFileSize(); }
        }

        /// <summary>
        /// Adds the given list of songs to the playlist.
        /// </summary>
        /// <param name="songs"></param>
        public long AddRange(IEnumerable<Song> songs)
        {
            foreach (Song song in songs)
            {
                if (!(_added.Contains(song)))
                {
                    // Add the song
                    _added.Add(song);

                    // Add the song to _songs
                    if (!(_songs.Contains(song)))
                        _songs.Add(song);
                }
            }

            return _songs.GetTotalFileSize();
        }

        /// <summary>
        /// Makes the playlist fit to the given size, in bytes.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the playlist is being fitted to the given size,
        /// songs will be removed from it as long as the total file size
        /// of all songs in playlist is less than equal to the given size.
        /// </para>
        /// <para>
        /// However, the fit operation wont remove any items added manually
        /// to the playlist. If the space used after <c>FitToSize</c> is used,
        /// this means there's more songs added to the playlist manually than
        /// there's available space. In such scenario one should manually remove
        /// songs via the <c>Remove</c> method
        /// </para>
        /// </remarks>
        /// <param name="targetSize">the target file size of the playlist</param>
        /// <returns>space used in bytes after fitting</returns>
        public long FitToSize(long targetSize)
        {
            long currentSize = _songs.GetTotalFileSize();

            if (targetSize >= currentSize)
                return currentSize;

            // Select randomly as many songs as needed to fit the target size
            long spaceLeft = currentSize - targetSize;
            Random random = new Random();
            List<Song> reshuffle = new List<Song>();
            List<Song> availableSongs = new List<Song>(_songs);

            while (spaceLeft >= 0)
            {
                List<Song> availableSongsTmp = new List<Song>();

                // Calculate available songs
                foreach (Song song in availableSongs)
                {
                    if (!(_added.Contains(song)))
                        availableSongsTmp.Add(song);
                }

                // Select a random song
                availableSongs = availableSongsTmp;

                if (availableSongs.Count == 0)
                    break;

                Song randomSong = availableSongs[random.Next(availableSongs.Count)];
                reshuffle.Add(randomSong);
                spaceLeft -= randomSong.FileSize;
            }

            // Remove the songs from _songs
            foreach (Song song in reshuffle)
                _songs.Remove(song);
            
            // Reshuffle any remaining space
            return DoShuffle(spaceLeft, _songs);
        }

        public long Remove(Song song)
        {
            List<Song> removeSongs = new List<Song>();
            removeSongs.Add(song);

            return Remove(removeSongs);
        }

        /// <summary>
        /// Removes all songs in the given list from this playlist.
        /// </summary>
        /// <param name="songs">the songs to remove</param>
        /// <returns>the total size of this playlist after removing</returns>
        public long Remove(IEnumerable<Song> songs)
        {
            long totalSize = _songs.GetTotalFileSize();

            foreach (Song song in songs)
            {
                if (_songs.Contains(song))
                {
                    _songs.Remove(song);
                    totalSize -= song.FileSize;

                    if (_added.Contains(song))
                        _added.Remove(song);
                }
            }

            return totalSize;
        }

        /// <summary>
        /// Fills the playlist with random songs until the total file size of
        /// the playlist is approximately the given total file size, in bytes.
        /// </summary>
        /// <param name="bytes">maximum total file size</param>
        /// <returns>the total file size of the playlist after shuffling</returns>
        public long Shuffle(long targetSize)
        {
            // Clear the previous playlist
            _songs.Clear();

            // Add the manually added items
            foreach (Song song in _added)
            {
                _songs.Add(song);
                targetSize -= song.FileSize;
            }

            // Shuffle
            return DoShuffle(targetSize, _added);
        }

        /// <summary>
        /// Reshuffles the specified items in the playlist.
        /// </summary>
        /// <param name="reshuffle">the items to reshuffle</param>
        /// <returns>the total file size of this playlist after reshuffling</returns>
        public long Shuffle(List<Song> reshuffle)
        {
            long spaceLeft = 0;

            foreach (Song removeSong in reshuffle)
            {
                if (!(_added.Contains(removeSong)))
                {
                    if (_songs.Contains(removeSong))
                    {
                        _songs.Remove(removeSong);
                        spaceLeft += removeSong.FileSize;
                    }
                }
            }

            // Reshuffle
            List<Song> skip = new List<Song>(_added);
            skip.AddRange(_songs);

            return DoShuffle(spaceLeft, skip);
        }

        private long DoShuffle(long targetSize, IEnumerable<Song> skip)
        {
            // Get a list of available songs
            List<Song> availableSongs = new List<Song>(_availableSongs);
            Random random = new Random();

            // Shuffle the rest of the playlist
            while (targetSize >= 0)
            {
                List<Song> availableSongsTmp = new List<Song>();

                // Calculate which songs may still be used
                foreach (Song song in availableSongs)
                {
                    if (song.FileSize <= targetSize)
                    {
                        // Check that the song isn't already on the playlist
                        if (!(_songs.Contains(song)) && !(skip.Contains(song)))
                        {
                            // This song may be used
                            availableSongsTmp.Add(song);
                        }
                    }
                }

                availableSongs = availableSongsTmp;

                // Break if there's no songs left to choose
                if (availableSongs.Count == 0)
                    break;

                // Get a random song
                Song randomSong = availableSongs[random.Next(availableSongs.Count)];
                _songs.Add(randomSong);
                targetSize -= randomSong.FileSize;
            }

            return _songs.GetTotalFileSize();
        }
    }
}
