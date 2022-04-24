using CQRS_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.Context
{
    public class CQRSContext : DbContext
    {
        public CQRSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        //    optionsBuilder.UseMySql("server=localhost;database=cqrsdb;user=root;port=3306;password=toortoor", serverVersion);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Quantity);
                entity.Property(e => e.Price);
                entity.Property(e => e.CreateTime);
            });
            
        }

    }
}
