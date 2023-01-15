using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Lab3.DAL.Entities;
using Lab3.DAL.Map;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DAL.EF
{
    public class TheatreContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Performance> Performance { get; set; } = null!;

        private string stringConnection;

        public TheatreContext(string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Theatre;Trusted_Connection=True;")
        {
            this.stringConnection = connectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(stringConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyAllConfiguration(modelBuilder);

            SetDefaultData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private void ApplyAllConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerformanceMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
        }

        private void SetDefaultData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Performance>().HasData(Services.PerformanceService.GetPerformance());
            modelBuilder.Entity<Ticket>().HasData(Services.TicketService.GetTicket());
        }
    }

    //public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TheatreContext>
    //{
    //    protected override void Seed(TheatreContext db)
    //    {
    //        db.Performance.Add(new Performance { Author = "Shevchenko", Name = "Katerina", Genre = "Roman", Date = DateTime.Now });
    //        db.Performance.Add(new Performance { Author = "Orvel", Name = "1094", Genre = "Roman", Date = DateTime.Now });
    //        db.Performance.Add(new Performance { Author = "Avtor", Name = "Knizhka", Genre = "Zhanr", Date = DateTime.Now });
    //        db.Performance.Add(new Performance { Author = "Franko", Name = "Diti", Genre = "Virsh", Date = DateTime.Now });
    //        db.SaveChanges();
    //    }
    //}
}
