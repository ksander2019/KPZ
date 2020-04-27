using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class UnableToSetAmountLessThan1Exception : Exception
    {
        public override string Message => Properties.strings.AmountGreaterThanZero;
    }
    class IDNotUniqueException : Exception
    {
        public override string Message => Properties.strings.IDMustBeUnique;
    }

    class Books
    {
        private List<Book> books = new List<Book>();

        public void AddBook(string author, string title, string genre, int year, int amount, int id)
        {
            if (books.Exists(Book => Book.Id == id))
            {
                IDNotUniqueException ex = new IDNotUniqueException();
                WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                throw new IDNotUniqueException();
            }
            if (amount < 1)
            {
                UnableToSetAmountLessThan1Exception ex = new UnableToSetAmountLessThan1Exception();
                WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);

                throw new UnableToSetAmountLessThan1Exception();
            }

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
                bookList += String.Format("{0}: {1} {2}: {3} {4}: {5} {6}: {7} {8}: {9} {10}: {11}\n",
                Properties.strings.ID, book.Id, Properties.strings.Title, book.Title, Properties.strings.Author,
                book.Author, Properties.strings.Genre, book.Genre, Properties.strings.Year, book.Year, 
                Properties.strings.Amount, book.Amount);
            }
            return bookList;
        }
    }
}
