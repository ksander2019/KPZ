using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class Books
    {
        private List<Book> books = new List<Book>();

        public void AddBook(string author, string title, string genre, int year, int amount, int id)
        {
            books.Add(new Book(author, title, genre, year, amount, id));
        }
        public void RemoveBook(int id)
        {
            books.RemoveAll(Book => Book.Id == id);
        }

        public string ShowBooks()
        {
            string bookList = "";
            foreach (Book book in books)
            {
                bookList += String.Format("ID: {0} Назва: {1} Автор: {2} Жанр: {3} Рік: {4} Кількість: {5}\n",
                book.Id, book.Title, book.Author, book.Genre, book.Year, book.Amount);


            }
            return bookList;
        }
    }
}
