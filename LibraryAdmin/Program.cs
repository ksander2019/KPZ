using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            Books books = new Books();
            View view = new View();
            Controller controller = new Controller(books, view);
            
            view.Run();

            Console.ReadLine();

        }
    }
}
