using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.DAL.EF;
using Lab3.DAL.Entities;
using Lab3.DAL.Interfaces;

namespace Lab3.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private TheatreContext db;
        private PerformanceRepository performanceRepository;
        private TicketRepository ticketRepository;

        public EFUnitOfWork(string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Theatre;Trusted_Connection=True;")
        {
            db = new TheatreContext(connectionString);
        }
        public IRepository<Performance> Performances
        {
            get
            {
                if (performanceRepository == null)
                    performanceRepository = new PerformanceRepository(db);
                return performanceRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(db);
                return ticketRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

