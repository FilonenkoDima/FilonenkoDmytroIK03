using Lab3.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.BLL.Services;

namespace Lab3.UIL.Configurations
{
    public static class Config
    {
        public static EFUnitOfWork db = new Lab3.BLL.Infrastructure.ServiceModule().InitDatabase();

        public static TicketService ticketBLL = new TicketService(db);
        public static PerformanceService performanceBLL = new PerformanceService(db);

    }
}
