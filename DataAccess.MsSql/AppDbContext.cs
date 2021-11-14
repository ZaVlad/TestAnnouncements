using Entities;
using Infrastructure.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.MsSql
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }
        public DbSet<Announcement> Announcement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfigure(modelBuilder);
            SeedData(modelBuilder);
        }

        private void ModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>().HasKey(s => s.Id);
            modelBuilder.Entity<Announcement>().Property(s => s.Description).IsRequired();
            modelBuilder.Entity<Announcement>().Property(s => s.Title).IsRequired();
            modelBuilder.Entity<Announcement>().Property(s => s.DateAdded).IsRequired();

        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>().HasData(new List<Announcement>()
            {
                new Announcement(){Id = 1,Description = "Some announcement 1",Title="Best Announcement in the World",DateAdded = DateTime.Now },
                new Announcement(){Id = 2,Description = "Some announcement 2",Title="Best Announcement in the Universe",DateAdded = DateTime.Now },
                new Announcement(){Id = 3,Description = "Some announcement 3",Title="Buy new cheap goods!",DateAdded = DateTime.Now },
            });
        }
    }
}
