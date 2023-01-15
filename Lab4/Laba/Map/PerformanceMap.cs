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
    public class PerformanceMap : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            builder.ToTable("Performance").HasKey(x => x.Id);

            builder.Property(p => p.Author).IsRequired().HasMaxLength(70).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(70).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Genre).IsRequired().HasMaxLength(70).IsUnicode(true).HasColumnType("nvarchar");
            builder.Property(p => p.Date).IsRequired();
        }
    }
}
