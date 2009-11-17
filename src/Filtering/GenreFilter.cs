using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShuffler.Filtering
{
    public class GenreFilter :IFilter
    {
        private IEnumerable<string> _excludeGenres;

        public GenreFilter(IEnumerable<string> excludeGenres)
        {
            if (excludeGenres == null)
                throw new ArgumentException("excludeGenres must not be null");

            _excludeGenres = excludeGenres;
        }

        public bool Filter(Song song)
        {
            // Filter out the song if it's genre is in _excludeGenres
            return _excludeGenres.Contains(song.GenreName);
        }
    }
}
