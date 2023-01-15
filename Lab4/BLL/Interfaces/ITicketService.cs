using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.BLL.DTO;

namespace Lab3.BLL.Interfaces
{
    public interface ITicketService
    {
        TicketDTO GetTicket(int? id);
        List<TicketDTO> GetByPerformanceId(int performanceId);
        List<TicketDTO> GetTickeByBooked();
        List<TicketDTO> GetTickeBySold();
        void DeleteTicket(int? id);
        void AddTicket(TicketDTO ticketDTO);
        List<TicketDTO> GetAll();
        void UpdateTicket (TicketDTO ticketDTO);

    }
}
