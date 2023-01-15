using Lab3.UIL.Menu;
using Lab3.UIL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.UIL.Configurations;
using Lab3.UIL.Models;
using AutoMapper;
using Lab3.BLL.DTO;
using Lab3.BLL.Infrastructure;

namespace Lab3.UIL.Demo
{
    public static class TicketServiceDemo
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.TicketMenu();
                ChooseTicketServices(Service.CheckNumber(1, 8));
            }
        }
        private static void ChooseTicketServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    PrintTicketById();
                    break;
                case 2:
                    PrintTicketByPerformanceId();
                    break;
                case 3:
                    PrintTicketBySold();
                    break;
                case 4:
                    PrintTicketByBooked();
                    break;
                case 5:
                    DeleteTicket();
                    break;
                case 6:
                    AddNewTicket();
                    break;
                case 7:
                    MainDemo.Start();
                    break;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }
        private static void PrintTicketById()
        {
            Console.Write("Enter ticket id: ");
            int numberId = Service.CheckNumber(1);
            var ticket = Config.ticketBLL.GetTicket(numberId);
            Console.WriteLine($"Id: {ticket.Id}; PerformanceId: {ticket.PerformanceId}; Price: {ticket.Price}; " +
                $"IsSold: {ticket.IsSold}; IsBooked: {ticket.IsBooked}. ");
            Console.ReadLine();
        }        
        
        private static void PrintTicketByPerformanceId()
        {
            Console.Write("Enter performance id: ");
            int numberId = Service.CheckNumber(1);
            var ticket = Config.ticketBLL.GetByPerformanceId(numberId);
            foreach (var item in ticket)
            {
                Console.WriteLine($"Id: {item.Id}; PerformanceId: {item.PerformanceId}; Price: {item.Price}; " +
                    $"IsSold: {item.IsSold}; IsBooked: {item.IsBooked}. ");
            }
            Console.ReadLine();
        }

        private static void PrintTicketBySold()
        {
            var ticket = Config.ticketBLL.GetTickeBySold();
            foreach (var item in ticket)
            {
                Console.WriteLine($"Id: {item.Id}; PerformanceId: {item.PerformanceId}; Price: {item.Price}; " +
                    $"IsSold: {item.IsSold}; IsBooked: {item.IsBooked}. ");
            }
            Console.ReadLine();
        }

        private static void PrintTicketByBooked()
        {
            var ticket = Config.ticketBLL.GetTickeByBooked();
            foreach (var item in ticket)
            {
                Console.WriteLine($"Id: {item.Id}; PerformanceId: {item.PerformanceId}; Price: {item.Price}; " +
                    $"IsSold: {item.IsSold}; IsBooked: {item.IsBooked}. ");
            }
            Console.ReadLine();
        }

        private static void DeleteTicket()
        {
            Console.Write("Enter ticket id: ");
            int numberId = Service.CheckNumber(1);
            Config.ticketBLL.DeleteTicket(numberId);
            Console.WriteLine($"Ticked deleted by id: {numberId}");
            Console.ReadLine();
        }


        private static void AddNewTicket()
        {
            TicketModel ticketModel = new TicketModel();

            ticketModel.Id = default(int);

            Console.Write("Enter performance id: ");
            ticketModel.PerformanceId = Service.CheckNumber(0);

            Console.Write("Enter price: ");
            ticketModel.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter IsBooked: ");
            ticketModel.IsBooked = bool.Parse(Console.ReadLine());

            Console.Write("Enter IsSold: ");
            ticketModel.IsSold = bool.Parse(Console.ReadLine());


            try
            {
                var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketModel, TicketDTO>()));
                Config.ticketBLL.AddTicket(Mapper.Map<TicketModel, TicketDTO>(ticketModel));
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("New ticket added successfully"); }
            Console.ReadLine();
        }
    }
}
