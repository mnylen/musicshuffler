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
    /// A class for storing presets for the <c>PlaylistGenerator</c>
    /// </summary>
    [XmlRoot(ElementName="Presets")]
    public class Presets
    {
        private string destinationDirectory;
        private List<string> searchDirectories = new List<string>();
        private List<string> excludeArtists = new List<string>();
        private List<string> excludeGenres = new List<string>();
        private TimeSpan minimumDuration = new TimeSpan(0, 0, 30);
        private TimeSpan maximumDuration = new TimeSpan(1, 0, 0);
        private long targetSize = 0;

        /// <summary>
        /// Gets or sets amount of bytes to shuffle music to the destination
        /// directory.
        /// </summary>
        [XmlElement(ElementName="TargetSize")]
        public long TargetSize
        {
            get { return targetSize; }
            set { targetSize = value; }
        }

        /// <summary>
        /// Gets or sets the destination directory
        /// </summary>
        [XmlElement(ElementName="DestinationDirectory")]
        public string DestinationDirectory
        {
            get { return destinationDirectory; }
            set { destinationDirectory = value; }
        }

        /// <summary>
        /// Gets or sets a list of directories to search
        /// </summary>
        [XmlArray(ElementName="SearchDirectories")]
        [XmlArrayItem(ElementName="Directory")]
        public List<string> SearchDirectories
        {
            get { return searchDirectories; }
            set { searchDirectories = value; }
        }

        /// <summary>
        /// Gets or sets a list of artists to exclude
        /// </summary>
        [XmlArray(ElementName="ExcludeArtists")]
        [XmlArrayItem(ElementName="Artist")]
        public List<string> ExcludeArtists
        {
            get { return excludeArtists; }
            set { excludeArtists = value; }
        }

        /// <summary>
        /// Gets or sets a list of genres to exclude
        /// </summary>
        [XmlArray(ElementName="ExcludeGenres")]
        [XmlArrayItem(ElementName="Genre")]
        public List<string> ExcludeGenres
        {
            get { return excludeGenres; }
            set { excludeGenres = value; }
        }

        /// <summary>
        /// Gets or sets the minimum duration of a song
        /// </summary>
        [XmlIgnore]
        public TimeSpan MinimumDuration
        {
            get { return minimumDuration; }
            set { minimumDuration = value; }
        }

        /// <summary>
        /// Gets or sets the maximum duration of a song
        /// </summary>
        [XmlIgnore]
        public TimeSpan MaximumDuration
        {
            get { return maximumDuration; }
            set { maximumDuration = value; }
        }

        [XmlElement("MinimumDuration")]
        public string XmlMinimumDuration
        {
            get { return minimumDuration.ToString(); }
            set { minimumDuration = TimeSpan.Parse(value); }
        }

        [XmlElement("MaximumDuration")]
        public string XmlMaximumDuration
        {
            get { return maximumDuration.ToString(); }
            set { maximumDuration = TimeSpan.Parse(value); }
        }

        public void Save()
        {
            string filePath = Utils.GetConfigurationFilePath();

            try
            {
                XmlSerializationTool<Presets>.Save(this,
                    filePath);
            }
            catch (Exception e)
            {
                // TODO: Log the error

            }
        }

        public static Presets Load()
        {
            string filePath = Utils.GetConfigurationFilePath();

            try
            {
                return XmlSerializationTool<Presets>.Load(
                    filePath);
            }
            catch (Exception e)
            {
                // TODO: Log the error
                return null;
            }
        }
    }
}
