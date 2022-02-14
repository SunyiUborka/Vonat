using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VonatCommon.Models;

namespace VonatCommon
{
    class AdminDbContext : DbContext
    {
        public DbSet<Cities> cities { get; set; }
        public DbSet<Railways> railways { get; set; }
        public DbSet<Users> users { get; set; }
        public AdminDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>().HasKey(s => s.Id);
            modelBuilder.Entity<Railways>().HasKey(s => s.Id);
            modelBuilder.Entity<Users>().HasKey(s => s.email);
            base.OnModelCreating(modelBuilder);
        }
    }
}
