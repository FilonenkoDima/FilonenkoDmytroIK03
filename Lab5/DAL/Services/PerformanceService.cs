using Lab3.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Services
{
    public static class PerformanceService
    {
        public static List<Performance> GetPerformance(string fileName = Config.performanceFilePath)
        {
            List<Performance> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> airCraftInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Performance
                    {
                        Id = int.Parse(airCraftInfo[0]),
                        Author = airCraftInfo[1],
                        Name = airCraftInfo[2],
                        Genre = airCraftInfo[3],
                        Date = DateTime.Parse(airCraftInfo[4])
                    }
                );
            }
            return result;
        }
    }
}
