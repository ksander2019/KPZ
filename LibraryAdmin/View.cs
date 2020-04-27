using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class View
    {
        Controller controller;

        public Controller Controller { get => controller; set => controller = value; }

        public void GeneralPrompt()
        {
            Console.WriteLine("1) Додати книгу");
            Console.WriteLine("2) Видалити книгу");
            Console.WriteLine("3) Показати книги");
            Console.WriteLine("4) Вийти");
        }

        public void Run()
        {
            
            Console.WriteLine("Адміністрування архіву бібліотеки");
            GeneralPrompt();
            bool b = true;
            while (b)
            {
                int input = Int32.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("Введіть через кому ID, автора, назву, жанр, рік видання, кількість примірників:");
                    string s = Console.ReadLine();
                    string[] a = s.Split(',');

                    int amount = Int32.Parse(a[5]);
                    int year = Int32.Parse(a[4]);
                    int id = Int32.Parse(a[0]);

                    for (int i = 1; i < 4; i++)
                    {
                        a[i] = a[i].Trim(' ');
                    }
                    controller.Add(a[1], a[2], a[3], year, amount, id);
                }
                else if (input == 2)
                {
                    Console.Write("Введіть ID книги: ");
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

                GeneralPrompt();
            }

        }

        
    }
}
