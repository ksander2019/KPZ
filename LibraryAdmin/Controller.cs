using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class Controller
    {
        private Books books;
        private View view;


        public Controller(Books model, View ui)
        {
            this.books = model;
            this.view = ui;

            this.view.Controller = this;

        }

        public void Add(string author, string title, string genre, int year, int amount, int id)
        {
            books.AddBook(author, title, genre, year, amount, id);
        }

        public void Remove(int id)
        {
            books.RemoveBook(id);
        }

        public string GetList()
        {
            return books.ShowBooks();
        }

    }
}
