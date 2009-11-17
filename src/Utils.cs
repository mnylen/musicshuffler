using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MusicShuffler
{
    public static class Utils
    {
        public static string GetLibraryPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"MusicShuffler\Library.xml");
        }

        public static string GetConfigurationFilePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"MusicShuffler\Presets.config.xml");
        }

        /// <summary>
        /// Converts the given file size, in bytes, to a human readable format
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToHumanReadableFileSize(long length)
        {
            // File sizes below zero are not supported
            if (length < 0)
                throw new ArgumentOutOfRangeException("length < 0");

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = " ";
            provider.NumberDecimalSeparator = ",";

            // For special case length == 0 we must have special handler
            if (length == 0L)
                return "0 KB";

            // Use format ## ### KB for file sizes less than 100 MB
            else if (length < (100 * Constants.MEGABYTE))
                return String.Format(provider, "{0:##,###} KB", (length / 1024L));

            // Use format ### MB for file sizes less than 1 GB
            else if (length < Constants.GIGABYTE)
                return String.Format(provider, "{0:###} MB", (length / (double)Constants.MEGABYTE));

            // For file sizes greater than 1 GB use format #,###.# GB
            else
                return String.Format(provider, "{0:#,###.#} GB", (length / (double)Constants.GIGABYTE));
        }

        public static long GetAvailableFreeSpace(string path, bool onlyRemovable)
        {
            // Get the drive for the path
            DriveInfo drive = GetDriveForPath(path);

            // Return the available free space if the drive exists
            if (drive != null)
            {
                if (onlyRemovable && drive.DriveType != DriveType.Removable)
                    return -1L;

                return drive.AvailableFreeSpace;
            }

            // Otherwise return -1L indicating that the free space could not be
            // calculated
            return -1L;
        }

        public static DriveInfo GetDriveForPath(string path)
        {
            // Get the root directory
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path).Root;

                // Try get the drive using the root path
                DriveInfo drive = new DriveInfo(dir.Name);

                // Check that the drive is ready
                if (drive.IsReady)
                    return drive;
            }
            catch
            {
                // TODO: Log the error

            }
            return null;
        }
    }
}
