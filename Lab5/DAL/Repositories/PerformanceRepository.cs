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
    public class PerformanceRepository : IRepository<Performance>
    {
        private TheatreContext db;

        public PerformanceRepository(TheatreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Performance> GetAll()
        {
            return db.Performance;
        }

        public Performance Get(int id)
        {
            return db.Performance.Find(id);
        }

        public void Create(Performance performance)
        {
            db.Performance.Add(performance);
        }

        public void Update(Performance performance)
        {
            db.Entry(performance).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public IEnumerable<Performance> Find(Func<Performance, Boolean> predicate)
        {
            return db.Performance.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            var performance = db.Performance.Find(id);
            if (performance != null)
                db.Performance.Remove(performance);
        }
    }
}
