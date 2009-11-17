using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShuffler.Filtering
{
    public class FilterChain
    {
        public List<IFilter> Filters = new List<IFilter>();

        public List<Song> Filter(IEnumerable<Song> songs)
        {
            if (songs == null)
                throw new ArgumentNullException("songs");

            if (Filters == null)
                throw new ArgumentNullException("Filters");

            List<Song> notFiltered = new List<Song>();
            
            foreach (Song song in songs)
            {
                bool filtered = false;

                foreach (IFilter filter in Filters)
                {
                    if (filter.Filter(song))
                    {
                        filtered = true;
                        break;
                    }
                }

                if (!filtered)
                    notFiltered.Add(song);
            }

            return notFiltered;
        }
    }
}
