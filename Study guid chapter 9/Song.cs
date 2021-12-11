using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_guid_chapter_9
{
    class Song
    {
        private string name;
        private string author;
        private Song previous_song;
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
        }
        public Song(string name, string author, Song previous_song)
        {
            this.name = name;
            this.author = author;
            this.previous_song = previous_song;
        }
        public Song()
        {
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public Song PreviousSong
        {
            get
            {
                return previous_song;
            }
            set
            {
                previous_song = value;
            }
        }
        public string Title()
        {
            return $"{name} {author}";
        }
        public override bool Equals(object song)
        {
            Song representation = song as Song;
            if (representation is null)
            {
                return false;
            }
            if (name.Equals(representation.name) && author.Equals(representation.author))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (40591 * 42589 + name.GetHashCode()) * 42589 + author.GetHashCode();
        }
    }
}
