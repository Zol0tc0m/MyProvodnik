using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проводник
{
    internal class Strelki
    {
        public static int Show(int minimum, int maximum)
        {
            {
                int posission = 0;
                ConsoleKeyInfo key;

                do
                {
                    Console.SetCursorPosition(0, posission);
                    Console.WriteLine("->");

                    key = Console.ReadKey();

                    Console.SetCursorPosition(0, posission);
                    Console.WriteLine("  ");

                    if (key.Key == ConsoleKey.UpArrow && posission != minimum)
                    {
                        posission--;
                        
                    }
                    else if (key.Key == ConsoleKey.DownArrow && posission != maximum)
                    {
                        posission++;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        return -1;
                    }
                    else if (key.Key == ConsoleKey.F1)
                    {


                    }

                } while (key.Key != ConsoleKey.Enter);
                return posission;
            }
        }
    }
}
