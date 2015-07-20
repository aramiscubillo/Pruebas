using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Entities
{
    public class Author
    {
        public string Name { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
