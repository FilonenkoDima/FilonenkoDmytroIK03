using Lab3.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Ticket> Tickets { get; }
        IRepository<Performance> Performances { get; }
        void Save();
    }
}
