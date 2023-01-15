using Lab3.BLL.DTO;
using Lab3.BLL.Interfaces;
using Lab3.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab3.DAL.Interfaces;
using Lab3.BLL.Infrastructure;


namespace Lab3.BLL.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork DataBase { get; set; }

        public TicketService(IUnitOfWork DataBase)
        {
            this.DataBase = DataBase;
        }
        public void DeleteTicket(int? id)
        {
            if (id == null)
                throw new ValidationException("Ticket id not set", "");
            var ticket = DataBase.Tickets.Get(id.Value);
            if (ticket == null)
                throw new ValidationException("Ticket not found", "");
            DataBase.Tickets.Delete(id.Value);
            DataBase.Save();
        }

        public List<TicketDTO> GetByPerformanceId(int performanceId)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()));
            IEnumerable<Ticket> tickets = DataBase.Tickets.Find(ticket => ticket.PerformanceId == performanceId);
            return Mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(tickets);
        }

        public List<TicketDTO> GetTickeByBooked()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Ticket> tickets = DataBase.Tickets.Find(ticket => ticket.IsBooked == true);
            return Mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(tickets);
        }

        public List<TicketDTO> GetTickeBySold()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Performance, PerformanceDTO>()));
            IEnumerable<Ticket> tickets = DataBase.Tickets.Find(ticket => ticket.IsSold == true);
            return Mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(tickets);
        }

        public TicketDTO GetTicket(int? id)
        {
            if (id == null)
                throw new ValidationException("Ticket id not set", "");
            var ticket = DataBase.Tickets.Get(id.Value);
            if (ticket == null)
                throw new ValidationException("Ticket not found", "");
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()));
            return Mapper.Map<Ticket, TicketDTO>(ticket);
        }

        public void AddTicket(TicketDTO ticketDTO)
        {
            Performance performance = DataBase.Performances.Get(ticketDTO.PerformanceId);

            Ticket ticket = new Ticket()
            {
                PerformanceId = performance.Id,
                Price = ticketDTO.Price,
                IsBooked= ticketDTO.IsBooked,
                IsSold= ticketDTO.IsSold
            };
            DataBase.Tickets.Create(ticket);
            DataBase.Save();

        }

        public List<TicketDTO> GetAll()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()));
            IEnumerable<Ticket> ticket = DataBase.Tickets.GetAll();
            return Mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(ticket);
        }

        public void UpdateTicket(TicketDTO ticketDTO)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()));
            if (ticketDTO == null)
                throw new ValidationException("Ticket doesn`t excist", "");
            DataBase.Tickets.Update(Mapper.Map<TicketDTO, Ticket>(ticketDTO));
        }
    }
}
