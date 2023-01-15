using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Entities
{
    public class Performance
    {
        public int Id { set; get; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Performance() 
        {
            Tickets= new List<Ticket>();
        }
    }

}
