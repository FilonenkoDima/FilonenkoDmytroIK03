using Lab3.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL.Map
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket").HasKey(x => x.Id);

            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.IsSold).IsRequired();
            builder.Property(p => p.IsBooked).IsRequired();

            builder.HasOne(a => a.Performance)
                    .WithMany(a => a.Tickets)
                    .HasForeignKey(a => a.PerformanceId)
                    .IsRequired();
        }
    }
}
