using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UIL.Services
{
    public static class Service
    {
        public static int CheckNumber()
        {
            int choose;
            while (!int.TryParse(Console.ReadLine(), out choose))
                Console.WriteLine("Invalid number, try again!");
            return choose;
        }

        public static int CheckNumber(int min)
        {
            int choose;
            while (!int.TryParse(Console.ReadLine(), out choose) || choose < min)
                Console.WriteLine("Invalid number, try again!");
            return choose;
        }

        public static int CheckNumber(int min, int max)
        {
            int choose;
            while (!int.TryParse(Console.ReadLine(), out choose) || choose > max || choose < min)
                Console.WriteLine("Invalid number, try again!");
            return choose;
        }
    }
}
