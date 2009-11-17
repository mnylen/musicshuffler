using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MusicShuffler
{
    /// <summary>
    /// Represents a song in library
    /// </summary>
    public class Song :IEquatable<Song>, IEquatable<string>
    {
        private string fileName = "";
        private long fileSize = 0L;
        private TimeSpan duration = new TimeSpan(0, 0, 0);
        private string artistName = "";
        private string albumName = "";
        private string genreName = "";
        private string title = "";
        private DateTime lastModified;

        /// <summary>
        /// Gets or sets the last known modified time of the song
        /// </summary>
        /// <remarks>
        /// This is used for detecting file changes when the library loads.
        /// </remarks>
        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        /// <summary>
        /// A hack for XmlSerializer
        /// </summary>
        [XmlElement(ElementName="Duration")]
        public string XmlDuration
        {
            get { return duration.ToString(); }
            set { duration = TimeSpan.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the duration of this song
        /// </summary>
        [XmlIgnore]
        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        /// <summary>
        /// Gets or sets the file name of this song
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            
            set
            {
                if (!File.Exists(value))
                    throw new FileNotFoundException(value);

                fileName = value;
            }
        }

        /// <summary>
        /// Gets or sets the file size of this song
        /// </summary>
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        /// <summary>
        /// Gets or sets the album for this song
        /// </summary>
        public string AlbumName
        {
            get { return (albumName == "") ? "Unknown album" : albumName; }
            set { if (value != null) albumName = value.Trim(); }
        }

        /// <summary>
        /// Gets or sets the artist name
        /// </summary>
        public string ArtistName
        {
            get { return (artistName == "") ? "Unknown artist" : artistName; }
            set { if (value != null) artistName = value.Trim(); }
        }

        /// <summary>
        /// Gets or sets the name of the genre
        /// </summary>
        public string GenreName
        {
            get { return (genreName == "") ? "Unknown" : genreName; }
            set { if (value != null) genreName = value.Trim(); }
        }

        /// <summary>
        /// Gets or sets the song title
        /// </summary>
        public string Title
        {
            get
            {
                if (title == "")
                {
                    if (fileName != "")
                    {
                        // Return file name without extension
                        return Path.GetFileNameWithoutExtension(fileName);
                    }

                    // There's nothing better so just return "unknown title"
                    return "Unknown title";
                }
                else
                {
                    // Return the title
                    return title;
                }
            }

            set { if (value != null) title = value.Trim(); }
        }

        /// <summary>
        /// Returns <c>true</c> if the <c>FileName</c> properties
        /// are equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Song other)
        {
            return (other == null) ? false : other.FileName == fileName;
        }

        /// <summary>
        /// Returns <c>true</c> if the <c>FileName</c> property of this
        /// song equals to the given string
        /// </summary>
        /// <param name="other">the string</param>
        /// <returns></returns>
        public bool Equals(string other)
        {
            return (other == null) ? false : other == fileName;
        }

        /// <summary>
        /// Returns the song title
        /// </summary>
        /// <returns>song title</returns>
        public override string ToString()
        {
            return Title;
        }
    }
}
