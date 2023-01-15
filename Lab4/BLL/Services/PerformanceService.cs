using Lab3.BLL.DTO;
using Lab3.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.DAL.Entities;
using Lab3.DAL.Interfaces;
using Lab3.BLL.Infrastructure;
using AutoMapper;

namespace Lab3.BLL.Services
{
    public class PerformanceService : IPerformanceService
    {
        IUnitOfWork DataBase { get; set; }

        public PerformanceService(IUnitOfWork DataBase)
        {
            this.DataBase = DataBase;
        }
        public void AddNewPerformance(PerformanceDTO performanceDTO)
        {
            Performance performance = new Performance()
            {
                Author = performanceDTO.Author,
                Name = performanceDTO.Name,
                Genre = performanceDTO.Genre,
                Date = performanceDTO.Date
            };
            DataBase.Performances.Create(performance);
            DataBase.Save();
        }

        public void DeletePerformance(int? id)
        {
            if (id == null)
                throw new ValidationException("Performance id not set", "");
            var performance = DataBase.Performances.Get(id.Value);
            if (performance == null)
                throw new ValidationException("Performance not found", "");
            DataBase.Performances.Delete(id.Value);
            DataBase.Save();
        }

        public List<PerformanceDTO> GetAllPerformance()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Performance> performance = DataBase.Performances.GetAll();
            return Mapper.Map<IEnumerable<Performance>, List<PerformanceDTO>>(performance);
        }

        public List<PerformanceDTO> GetPerformanceByAuthor(string author)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Performance> performances = DataBase.Performances.Find(performances => performances.Author == author);
            return Mapper.Map<IEnumerable<Performance>, List<PerformanceDTO>>(performances);
        }

        public List<PerformanceDTO> GetPerformanceByDate(DateTime date)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Performance> performances = DataBase.Performances.Find(performances => performances.Date == date);
            return Mapper.Map<IEnumerable<Performance>, List<PerformanceDTO>>(performances);
        }

        public List<PerformanceDTO> GetPerformanceByGenre(string genre)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Performance> performances = DataBase.Performances.Find(performances => performances.Genre == genre);
            return Mapper.Map<IEnumerable<Performance>, List<PerformanceDTO>>(performances);
        }

        public PerformanceDTO GetPerformanceById(int? id)
        {
            if (id == null)
                throw new ValidationException("Performance id not set", "");
            var performance = DataBase.Performances.Get(id.Value);
            if (performance == null)
                throw new ValidationException("Performance not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            return Mapper.Map<Performance, PerformanceDTO>(performance);
        }

        public List<PerformanceDTO> GetPerformanceByName(string name)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Performance> performances = DataBase.Performances.Find(performances => performances.Name == name);
            return Mapper.Map<IEnumerable<Performance>, List<PerformanceDTO>>(performances);
        }

        public void UpdatePerformance(PerformanceDTO performanceDTO)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, Performance>()));
            if (performanceDTO == null)
                throw new ValidationException("Performance doesn`t excist", "");
            DataBase.Performances.Update(Mapper.Map<PerformanceDTO, Performance>(performanceDTO));
        }
    }
}
