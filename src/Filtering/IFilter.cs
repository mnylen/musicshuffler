using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShuffler.Filtering
{
    public interface IFilter
    {
        /// <summary>
        /// Returns whether the given song should be filtered out
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        bool Filter(Song song);
    }
}
