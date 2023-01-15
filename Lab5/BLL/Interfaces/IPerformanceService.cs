using Lab3.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL.Interfaces
{
    public interface IPerformanceService
    {
        PerformanceDTO GetPerformanceById(int? id);
        List<PerformanceDTO> GetPerformanceByAuthor(string author);
        List<PerformanceDTO> GetPerformanceByName(string name);
        List<PerformanceDTO> GetPerformanceByGenre(string genre);
        List<PerformanceDTO> GetPerformanceByDate(DateTime date);
        List<PerformanceDTO> GetAllPerformance();
        void AddNewPerformance(PerformanceDTO performanceDTO);
        void DeletePerformance(int? id);

    }
}
