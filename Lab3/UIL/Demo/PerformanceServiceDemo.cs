using Lab3.UIL.Menu;
using Lab3.UIL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.UIL.Configurations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Lab3.BLL.DTO;
using Lab3.UIL.Models;
using Lab3.BLL.Infrastructure;

namespace Lab3.UIL.Demo
{
    public static class PerformanceServiceDemo
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Menus.PerformanceMenu();
                ChoosePerformanceServices(Service.CheckNumber(1, 10));
            }
        }
        private static void ChoosePerformanceServices(int choose)
        {
            switch (choose)
            {
                case 1:
                    PrintPerformanceById();
                    break;
                case 2:
                    PrintPerformanceByAuthor();
                    break;
                case 3:
                    PrintPerformanceByName();
                    break;
                case 4:
                    PrintPerformanceByGenre();
                    break;
                case 5:
                    PrintPerformanceByDate();
                    break;
                case 6:
                    PrintAllPerformance();
                    break;
                case 7:
                    AddNewPerformance();
                    break;
                case 8:
                    DeletePerformance();
                    break;
                case 9:
                    MainDemo.Start();
                    break;
                default:
                    Console.Write("Invalid operation. Try again.");
                    break;
            }
        }

        private static void PrintPerformanceById()
        {
            Console.Write("Enter performance id: ");
            int numberId = Service.CheckNumber(1);
            var performance = Config.performanceBLL.GetPerformanceById(numberId);
            Console.WriteLine($"Id: {performance.Id}; Author: {performance.Author}; Name: {performance.Name}; " +
                $"Genre: {performance.Genre}; Date: {performance.Date.ToString()}. ");
            Console.ReadLine();
        }

        private static void PrintPerformanceByAuthor()
        {
            Console.Write("Enter performance author: ");
            string author = Console.ReadLine();
            var performance = Config.performanceBLL.GetPerformanceByAuthor(author);
            foreach (var item in performance)
            {
                Console.WriteLine($"Id: {item.Id}; Author: {item.Author}; Name: {item.Name}; " +
                    $"Genre: {item.Genre}; Date: {item.Date.ToString()}. ");
            }
            Console.ReadLine();
        }

        private static void PrintPerformanceByName()
        {
            Console.Write("Enter performance name: ");
            string name = Console.ReadLine();
            var performance = Config.performanceBLL.GetPerformanceByName(name);
            foreach (var item in performance)
            {
                Console.WriteLine($"Id: {item.Id}; Author: {item.Author}; Name: {item.Name}; " +
                    $"Genre: {item.Genre}; Date: {item.Date.ToString()}. ");
            }
            Console.ReadLine();
        }

        private static void PrintPerformanceByGenre()
        {
            Console.Write("Enter performance genre: ");
            string genre = Console.ReadLine();
            var performance = Config.performanceBLL.GetPerformanceByGenre(genre);
            foreach (var item in performance)
            {
                Console.WriteLine($"Id: {item.Id}; Author: {item.Author}; Name: {item.Name}; " +
                    $"Genre: {item.Genre}; Date: {item.Date.ToString()}. ");
            }
            Console.ReadLine();
        }


        private static void PrintPerformanceByDate()
        {
            Console.Write("Enter performance date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            var performance = Config.performanceBLL.GetPerformanceByDate(date);
            foreach (var item in performance)
            {
                Console.WriteLine($"Id: {item.Id}; Author: {item.Author}; Name: {item.Name}; " +
                    $"Genre: {item.Genre}; Date: {item.Date.ToString()}. ");
            }
            Console.ReadLine();
        }

        private static void PrintAllPerformance()
        {
            var performance = Config.performanceBLL.GetAllPerformance();
            foreach (var item in performance)
            {
                Console.WriteLine($"Id: {item.Id}; Author: {item.Author}; Name: {item.Name}; " +
                    $"Genre: {item.Genre}; Date: {item.Date.ToString()}. ");
            }
            Console.ReadLine();
        }

        private static void AddNewPerformance()
        {
            PerformanceModel performance = new PerformanceModel();

            performance.Id = default(int);

            Console.Write("Enter performance author: ");
            performance.Author = Console.ReadLine();

            Console.Write("Enter name: ");
            performance.Name = Console.ReadLine();

            Console.Write("Enter genre: ");
            performance.Genre = Console.ReadLine();

            Console.Write("Enter date: ");
            performance.Date = DateTime.Parse(Console.ReadLine());


            try
            {
                var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceModel, PerformanceDTO>()));
                Config.performanceBLL.AddNewPerformance(Mapper.Map<PerformanceModel, PerformanceDTO>(performance));
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("New ticket added successfully"); }
            Console.ReadLine();
        }

        private static void DeletePerformance()
        {
            Console.Write("Enter performance id: ");
            int numberId = Service.CheckNumber(1);
            Config.performanceBLL.DeletePerformance(numberId);
            Console.WriteLine($"Performance deleted by id: {numberId}");
            Console.ReadLine();
        }
    }
}
