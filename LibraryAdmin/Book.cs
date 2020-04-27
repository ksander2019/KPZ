using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }

        private Book() { }

        public Book(string author, string title, string genre, int year, int amount, int id)
        {
            Author = author;
            Title = title;
            Genre = genre;
            Year = year;
            Amount = amount;
            Id = id;
        }
    }
}
