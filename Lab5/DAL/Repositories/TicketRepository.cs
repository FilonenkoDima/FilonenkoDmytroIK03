using Lab3.DAL.EF;
using Lab3.DAL.Entities;
using Lab3.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab3.DAL.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private TheatreContext db;

        public TicketRepository(TheatreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets.Include(o => o.Performance);
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public void Create(Ticket tickets)
        {
            db.Tickets.Add(tickets);
        }

        public void Update(Ticket tickets)
        {
            db.Entry(tickets).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
        {
            return db.Tickets.Include(o => o.Performance).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var tickets = db.Performance.Find(id);
            if (tickets != null)
                db.Performance.Remove(tickets);
        }

    }
}
