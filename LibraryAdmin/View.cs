using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    [Serializable]
    class InvalidNumberOfArguementsException : Exception
    {
        public override string Message => Properties.strings.WrongNumberOfArguements;
    }
    class View
    {
        Controller controller;

        public Controller Controller { get => controller; set => controller = value; }

        public void GeneralPrompt()
        {
            Console.WriteLine("1) " + Properties.strings.AddBook);
            Console.WriteLine("2) " + Properties.strings.DeleteBook);
            Console.WriteLine("3) " + Properties.strings.ShowBooks);
            Console.WriteLine("4) " + Properties.strings.Exit);
        }

        public void Run()
        {

            Console.WriteLine(Properties.strings.Header);
            GeneralPrompt();
            bool b = true;
            while (b)
            {
                int input = 0;
                try
                {
                    input = Int32.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {

                    WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                    Console.WriteLine(Properties.strings.CommandMustBeNumber);

                }

                if (input == 1)
                {
                    Console.WriteLine(Properties.strings.BookDataPrompt);
                    string s = Console.ReadLine();
                    string[] a = s.Split(',');

                    if (a.Length != 6)
                    {
                        InvalidNumberOfArguementsException ex = new InvalidNumberOfArguementsException();
                        WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                        throw new InvalidNumberOfArguementsException();
                    }
                    try
                    {
                        int amount = Int32.Parse(a[5]);
                        int year = Int32.Parse(a[4]);
                        int id = Int32.Parse(a[0]);

                        for (int i = 1; i < 4; i++)
                        {
                            a[i] = a[i].Trim(' ');
                        }
                        controller.Add(a[1], a[2], a[3], year, amount, id);
                    }
                    catch (ArgumentException ex)
                    {
                        WriteLogFile.WriteLog("LibraryAdminLog.txt", ex.Message);
                        throw;
                    }

                    
                }
                else if (input == 2)
                {
                    Console.Write(Properties.strings.BookIDPrompt);
                    int index = Int32.Parse(Console.ReadLine());
                    controller.Remove(index);
                }
                else if (input == 3)
                {
                    Console.WriteLine(controller.GetList());
                }
                else if (input == 4)
                {
                    b = false;
                }
                else
                    Console.WriteLine(Properties.strings.CommandNotExists);

                GeneralPrompt();
            }

        }

        
    }
}
