using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    [Serializable]
    class UnableToSetAmountLessThan1Exception : Exception
    {
        public override string Message => Properties.strings.AmountGreaterThanZero;
    }
    [Serializable]
    class IDNotUniqueException : Exception
    {
        public override string Message => Properties.strings.IDMustBeUnique;
    }

    class Books
    {
        public void AddBook(string author, string title, string genre, int year, int amount, int id)
        {

            if (amount < 1)
            {
                UnableToSetAmountLessThan1Exception ex = new UnableToSetAmountLessThan1Exception();
                WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);

                throw new UnableToSetAmountLessThan1Exception();
            }

            using (BookContext db = new BookContext())
            {
                try
                {
                    db.Books.Add(new Book(author, title, genre, year, amount, id));
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                    throw;
                }

            }
        }
        public void RemoveBook(int id)
        {
            using (BookContext db = new BookContext())
            {
                try
                {
                    Book book = db.Books.Find(id);
                    if (book != null)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                    throw;
                }

            }
        }

        public string ShowBooks()
        {
            using (BookContext db = new BookContext())
            {
                try
                {
                    List<Book> books = db.Books.ToList();
                    string bookList = "";
                    foreach (Book book in books)
                    {
                        bookList += String.Format("{0}: {1} {2}: {3} {4}: {5} {6}: {7} {8}: {9} {10}: {11}\n",
                        Properties.strings.ID, book.Id, Properties.strings.Title, book.Title, Properties.strings.Author,
                        book.Author, Properties.strings.Genre, book.Genre, Properties.strings.Year, book.Year, Properties.strings.Amount, book.Amount);


                    }
                    return bookList;

                }
                catch (Exception ex)
                {
                    WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                    throw;
                }

            }

        }
    }
}
