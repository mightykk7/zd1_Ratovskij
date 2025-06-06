using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu
{
    internal struct Song
    {
        public string Author;
        public string Title;
        public string Filename;

        public Song(string title, string author, string filename)
        {
            Title = title;
            Author = author;
            Filename = filename;
        }
    }
}
