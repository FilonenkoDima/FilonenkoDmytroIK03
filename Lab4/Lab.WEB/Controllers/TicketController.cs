using AutoMapper;
using Lab3.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Configurations;
using Microsoft.IdentityModel.Tokens;
using Lab3.DAL.Entities;

namespace Lab.Swagger.Controllers
{
    public class TicketController : Controller
    {
        private TicketModel ticket = new TicketModel();
        public IActionResult Index()
        {
            return View(GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Find()
        {
            return View(ticket);
        }
        [HttpGet("GetAll")]
        public IEnumerable<TicketModel> GetAll()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketModel>()));
            var obj = Configurations.Config.ticketBLL;
            return Mapper.Map<IEnumerable<TicketDTO>, List<TicketModel>>(Configurations.Config.ticketBLL.GetAll());
        }

        public IActionResult GetTicketById(int id)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketModel>()));
            var ticket = Config.ticketBLL.GetTicket(id);
            if (ticket == null)
                return NotFound();
            return View(Mapper.Map<TicketDTO, TicketModel>(ticket));
        }

        [HttpPost("Ticket/GetTicketByPerformanceId")]
        public IActionResult GetTicketByPerformanceId(TicketModel t)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketModel>()));
            var ticket = Config.ticketBLL.GetByPerformanceId(t.Id);
            if (ticket == null)
                return NotFound();
            return View(Mapper.Map< IEnumerable<TicketDTO>, List<TicketModel>>(ticket));
        }

        [HttpGet("GetTicketByBooked")]
        public IActionResult GetTicketByBooked()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()));
            var ticket = Config.ticketBLL.GetTickeByBooked();
            if (ticket == null)
                return NotFound();
            return Ok(Mapper.Map<IEnumerable<TicketDTO>, List<Ticket>>(ticket));
        }

        [HttpGet("GetTicketBySold")]
        public IActionResult GetTicketBySold()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()));
            var ticket = Config.ticketBLL.GetTickeBySold();
            if (ticket == null)
                return NotFound();
            return Ok(Mapper.Map<IEnumerable<TicketDTO>, List<Ticket>>(ticket));
        }

        [HttpDelete("id")]
        public IActionResult DeleteMethod([FromBody]int id)
        {
            Config.ticketBLL.DeleteTicket(id);
            return Ok();
        }

        [HttpPost("Ticket/AddTicket")]
        public IActionResult Post(TicketModel ticket)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketModel, TicketDTO>()));

            Config.ticketBLL.AddTicket(Mapper.Map<TicketModel, TicketDTO>(ticket));
            return RedirectToAction("Index", "Ticket");
        }
        [HttpPost("Ticket/GetTicketById")]
        public IActionResult GetTicketById(TicketModel ticket)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketModel>()));

            if (ticket.Id != 0)
            {
                var t = Config.ticketBLL.GetTicket(ticket.Id);
                if (t == null)
                    return NotFound();
                return View(Mapper.Map<TicketModel>(t));
            }
            else if(ticket.PerformanceId != 0)
            {
                var t = Config.ticketBLL.GetByPerformanceId(ticket.PerformanceId);
                if (t == null)
                    return NotFound();
                return View(Mapper.Map<IEnumerable<TicketDTO>, List<TicketModel>>(t));
            }
            else if(ticket.IsBooked)
            {
                var t = Config.ticketBLL.GetTickeByBooked();
                if (t == null)
                    return NotFound();
                return Ok(Mapper.Map<IEnumerable<TicketDTO>, List<TicketModel>>(t));
            }
            else if (ticket.IsSold)
            {
                var t = Config.ticketBLL.GetTickeBySold();
                if (t == null)
                    return NotFound();
                return Ok(Mapper.Map<IEnumerable<TicketDTO>, List<TicketModel>>(t));
            }
            else
            {
                var t = Config.ticketBLL.GetTickeByBooked();
                if (t == null)
                    return NotFound();
                return Ok(Mapper.Map<IEnumerable<TicketDTO>, List<TicketModel>>(t));
            }
        }
        [HttpPost("Ticket/DeleteTicket")]
        public IActionResult Delete(int id)
        {
            Config.ticketBLL.DeleteTicket(id);
            return RedirectToAction("Index", "Ticket"); ;
        }
        [HttpPut]
        public IActionResult Put(TicketModel ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var storedTicket = Config.ticketBLL.GetTicket(ticket.Id);
            if (storedTicket == null)
                return NotFound();
            storedTicket.PerformanceId = ticket.PerformanceId;
            storedTicket.Price = ticket.Price;
            storedTicket.IsSold = ticket.IsSold;
            storedTicket.IsBooked = ticket.IsBooked;
            return Ok(storedTicket);
        }
    }
}
