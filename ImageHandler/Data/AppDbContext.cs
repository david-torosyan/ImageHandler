using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using System;
using ImageHandler.Models;

namespace ImageHandler.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Image> Images { get; set; }
        public DbSet<Image> Effects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}