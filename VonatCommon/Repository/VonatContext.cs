using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VonatCommon.Models;

namespace VonatCommon.Repository
{
    public class VonatContext : DbContext
    {
        private static VonatContext context = null;
        public static VonatContext Instance
        {
            get
            {
                if (context == null)
                {
                    context = new VonatContext();
                }
                return context;
            }
        }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Railways> Railways { get; set; }

        private VonatContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vasuthalozat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
