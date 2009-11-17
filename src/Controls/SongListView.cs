using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MusicShuffler;
using System.Collections;

namespace MusicShuffler.Controls
{
    public static class Column
    {
        public const int Title = 0;
        public const int Artist = 1;
        public const int Album = 2;
        public const int Genre = 3;
        public const int Duration = 4;
        public const int FileSize = 5;
        public const int FilePath = 6;
    }

    public class SongListView :ListView
    {
        private IEnumerable<Song> songs;
        private ListViewGroup topGroup;
        private IEnumerable<Song> topSongs;
        private Dictionary<int, Dictionary<string, ListViewGroup>> groupTables;
        private int currentGroupingColumn = Column.Artist;

        public ListViewGroup AlwaysOnTopGroup
        {
            get { return topGroup; }
            set { topGroup = value; }
        }

        public IEnumerable<Song> AlwaysOnTopSongs
        {
            get { return topSongs; }
            set { topSongs = value; SetItems(); }
        }

        public IEnumerable<Song> Songs
        {
            get { return songs; }
            set { songs = value; SetItems(); }
        }

        public SongListView()
        {
            // Set the properties
            this.View = View.Details;
            this.Size = new Size(800, 600);
            this.AllowColumnReorder = true;
            this.FullRowSelect = true;
            this.Sorting = SortOrder.Ascending;

            // Add the columns
            this.Columns.Add("title", Strings.SongList_Title, 200);
            this.Columns.Add("artist", Strings.SongList_Artist, 150);
            this.Columns.Add("album", Strings.SongList_Album, 100);
            this.Columns.Add("genre", Strings.SongList_Genre, 100);
            this.Columns.Add("duration", Strings.SongList_Duration, 70);
        }

        protected void SetItems()
        {
            if (songs == null)
                return;

            BeginUpdate();

            // First we need to calculate the groups
            CalculateGroups();

            // Clear the previous items
            this.Items.Clear();

            // Now add the items
            foreach (Song song in songs)
            {
                ListViewItem item = new ListViewItem(new string[] {
                    song.Title, song.ArtistName, song.AlbumName,
                    song.GenreName, song.Duration.ToHumanReadableString() });

                item.Tag = song;
                this.Items.Add(item);
            }

            // Set the groups
            SetGroups(currentGroupingColumn);

            EndUpdate();
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            // Call the base implementation first
            base.OnColumnClick(e);

            // Group by the column
            if (currentGroupingColumn == e.Column)
            {
                if (this.Sorting == SortOrder.Ascending)
                    this.Sorting = SortOrder.Descending;

                else
                    this.Sorting = SortOrder.Ascending;
            }
            else
            {
                this.Sorting = SortOrder.Ascending;
            }

            currentGroupingColumn = e.Column;
            SetGroups(currentGroupingColumn);
        }

        protected void CalculateGroups()
        {
            groupTables = new Dictionary<int, Dictionary<string, ListViewGroup>>();

            for (int col = 0; col <= Columns.Count; col++)
                groupTables[col] = CreateGroups(col);
        }

        protected Dictionary<string, ListViewGroup> CreateGroups(int col)
        {
            Dictionary<string, ListViewGroup> groups;

            switch (col)
            {
                case Column.Title:
                    // Create groups for title
                    groups = CreateTitleGroups();
                    break;

                case Column.Artist:
                    // Create groups for artist
                    groups = CreateArtistGroups();
                    break;

                default:
                    groups = new Dictionary<string, ListViewGroup>();
                    break;
            }

            return groups;
        }

        protected void SetGroups(int col)
        {
            BeginUpdate();

            // Clear the groups
            Groups.Clear();

            // Get a list of groups
            ListViewGroup[] groups =
                groupTables[col].Values.ToArray();

            // Sort the groups
            Array.Sort(groups, new GroupSorter(this.Sorting));

            // Add the groups
            this.Groups.AddRange(groups);
            List<ListViewItem> topItems = new List<ListViewItem>();

            // Assign each item to the group it belongs to
            foreach (ListViewItem item in this.Items)
            {
                Song song = item.Tag as Song;

                if (topSongs != null && topSongs.Contains(song))
                {
                    topItems.Add(item);
                    continue;
                }

                foreach (ListViewGroup group in groups)
                {
                    if (col == Column.Title)
                    {
                        // Compare the first character
                        if (group.Header == item.SubItems[col].Text[0].ToString())
                            item.Group = group;
                    }
                    else
                    {
                        // Compare the item
                        if (group.Header == item.SubItems[col].Text)
                            item.Group = group;
                    }
                }
            }

            // Add the always on top group
            if (topGroup != null)
            {
                this.Groups.Insert(0, topGroup);

                foreach (ListViewItem item in topItems)
                    topGroup.Items.Add(item);
                
            }

            EndUpdate();
        }

        private class GroupSorter : IComparer<ListViewGroup>
        {
            private SortOrder order;

            public GroupSorter(SortOrder order)
            {
                this.order = order;
            }

            public int Compare(ListViewGroup x, ListViewGroup y)
            {
                int result = String.Compare(x.Header, y.Header);
                return (order == SortOrder.Ascending) ? result : -result;
            }
        }

        protected Dictionary<string, ListViewGroup> CreateArtistGroups()
        {
            Dictionary<string, ListViewGroup> groups =
                new Dictionary<string, ListViewGroup>();
            
            foreach (Song song in songs)
            {
                string artistName = song.ArtistName;

                if (!(groups.ContainsKey(artistName)))
                    groups.Add(artistName, new ListViewGroup(artistName));
            }

            return groups;
        }

        protected Dictionary<string, ListViewGroup> CreateTitleGroups()
        {
            Dictionary<string, ListViewGroup> groups =
                new Dictionary<string, ListViewGroup>();

            foreach (Song song in songs)
            {
                string title = song.Title;

                if (!(groups.ContainsKey(song.Title[0].ToString())))
                {
                    groups.Add(song.Title[0].ToString(), new ListViewGroup(
                        song.Title[0].ToString()));
                }
            }

            return groups;
        }
    }
}
