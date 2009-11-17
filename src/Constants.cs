using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShuffler
{
    public static class Constants
    {
        /// <summary>
        /// Amount of bytes in kilobyte.
        /// </summary>
        public const long KILOBYTE = 1024L;

        /// <summary>
        /// Amount of bytes in megabyte.
        /// </summary>
        public const long MEGABYTE = KILOBYTE * 1024;

        /// <summary>
        /// Amount of bytes in gigabyte.
        /// </summary>
        public const long GIGABYTE = MEGABYTE * 1024;

        /// <summary>
        /// Amount of bytes in terabyte.
        /// </summary>
        public const long TERABYTE = GIGABYTE * 1024;
    }
}
