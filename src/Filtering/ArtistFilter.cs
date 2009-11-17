using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShuffler.Filtering
{
    public class ArtistFilter :IFilter
    {
        private IEnumerable<string> _excludeArtists;

        public ArtistFilter(IEnumerable<string> excludeArtists)
        {
            if (excludeArtists == null)
                throw new ArgumentException("excludeArtists must not be null");

            _excludeArtists = excludeArtists;
        }

        public bool Filter(Song song)
        {
            // Filter out the song if it's artist is excluded
            return _excludeArtists.Contains(song.ArtistName);
        }
    }
}
