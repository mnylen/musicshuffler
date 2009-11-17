using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShuffler.Filtering
{
    public class DurationFilter :IFilter
    {
        private TimeSpan _minDuration;
        private TimeSpan _maxDuration;

        public DurationFilter(TimeSpan minDuration, TimeSpan maxDuration)
        {
            _minDuration = minDuration;
            _maxDuration = maxDuration;
        }

        public bool Filter(Song song)
        {
            if (song.Duration >= _minDuration && song.Duration <= _maxDuration)
                return false;

            return true;
        }
    }
}
