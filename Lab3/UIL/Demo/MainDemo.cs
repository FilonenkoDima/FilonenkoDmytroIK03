using Lab3.UIL.Menu;
using Lab3.UIL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UIL.Demo
{
    public class MainDemo
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.MainMenu();
                ChooseServices(Service.CheckNumber(1, 4));
            }
        }

        private static void ChooseServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    TicketServiceDemo.Start();
                    break;
                case 2:
                    PerformanceServiceDemo.Start();
                    break;
                case 3:
                    return;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }
    }
}
