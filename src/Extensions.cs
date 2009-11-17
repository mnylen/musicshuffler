using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MusicShuffler
{
    /// <summary>
    /// Contains extensions for some types
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns the total file size, in bytes, of the songs contained in
        /// the given list of songs.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public static long GetTotalFileSize(this IEnumerable<Song> songs)
        {
            long totalFileSize = 0L;

            foreach (Song song in songs)
                totalFileSize += song.FileSize;

            return totalFileSize;
        }

        /// <summary>
        /// Returns the total duration of the songs in the given list of songs.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public static TimeSpan GetTotalDuration(this IEnumerable<Song> songs)
        {
            TimeSpan totalDuration = new TimeSpan();

            foreach (Song song in songs)
                totalDuration += song.Duration;

            return totalDuration;
        }

        /// <summary>
        /// Converts timespan to format hh:mm:ss or, alternatively if
        /// there's no full hours, mm:ss
        /// </summary>
        /// <param name="timeSpan">the time span to convert</param>
        /// <returns>the timespan in human readable format</returns>
        public static string ToHumanReadableString(this TimeSpan timeSpan)
        {
            if (timeSpan.TotalHours >= 1.0)
            {
                return String.Format(
                    "{0:00}:{1:00}:{2:00}",
                    (int)Math.Floor(timeSpan.TotalHours),
                    timeSpan.Minutes, timeSpan.Seconds);
            }
            else
            {
                return String.Format(
                    "{0:00}:{1:00}",
                    timeSpan.Minutes,
                    timeSpan.Seconds);
            }
        }
    }
}