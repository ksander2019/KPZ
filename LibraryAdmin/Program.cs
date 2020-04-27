using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            Books books = new Books();
            View view = new View();
            Controller controller = new Controller(books, view);
            
            view.Run();

            Console.ReadLine();

        }
    }
}
