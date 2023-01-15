using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public decimal Price { get; set; }
        public bool IsBooked { get; set; }
        public bool IsSold { get; set; }

        public Performance Performance { get; set; }
    }
}
