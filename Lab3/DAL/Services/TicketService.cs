using Lab3.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Services
{
    public static class TicketService
    {
        public static List<Ticket> GetTicket(string fileName = Config.ticketFilePath)
        {
            List<Ticket> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> airCraftInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Ticket
                    {
                        Id = int.Parse(airCraftInfo[0]),
                        PerformanceId = int.Parse(airCraftInfo[1]),
                        Price = decimal.Parse(airCraftInfo[2]),
                        IsBooked = bool.Parse(airCraftInfo[3]),
                        IsSold = bool.Parse(airCraftInfo[4])
                    }
                );
            }
            return result;
        }
    }
}
