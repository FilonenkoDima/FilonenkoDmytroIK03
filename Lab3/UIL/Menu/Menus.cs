using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UIL.Menu
{
    public class Menus
    {
        public static void MainMenu()
        {
            Console.Write("\tMenu\n" +
                "1 - Ticket service\n" +
                "2 - Performance service\n" +
                "3 - Exit\n" +
                "Operation: ");
        }


        public static void TicketMenu()
        {
            Console.Write("\tTicket services\n" +
                "1 - Get ticket by id\n" +
                "2 - Get by performance id\n" +
                "3 - Get ticke by booked\n" +
                "4 - Get ticke by sold\n" +
                "5 - Delete ticket\n" +
                "6 - Create ticket\n" +
                "7 - Back\n" +
                "Operation: ");
        }

        public static void PerformanceMenu()
        {
            Console.Write("\tPerformance services\n" +
                "1 - Get performance by id\n" +
                "2 - Get performance by author\n" +
                "3 - Get performance by name\n" +
                "4 - Get performance by genre\n" +
                "5 - Get performance by date\n" +
                "6 - Get all performance\n" +
                "7 - Add new performance\n" +
                "8 - Delete performance\n" +
                "9 - Back\n" +
                "Operation: ");
        }
    }
}
