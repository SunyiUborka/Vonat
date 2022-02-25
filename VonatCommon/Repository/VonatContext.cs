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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vonat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void CreateCity(Cities city)
        {
            Instance.Cities.Add(city);
            Instance.SaveChanges();
        }

        public void UpdateCity(Cities city)
        {

        }

        public void DeleteCity(Cities city)
        {
            Instance.Cities.Remove(city);
            Instance.SaveChanges();
        }

        public Cities GetCity(Cities city)
        {
            return city;
        }

        public void CreateRailway(Railways railway)
        {
            Instance.Railways.Add(railway);
            Instance.SaveChanges();
        }

        public void UpdateRailways(Railways railway)
        {

        }

        public void DeleteRailways(Railways railway)
        {
            Instance.Remove(railway);
            Instance.SaveChanges();
        }

        public Railways GetRailways(Railways railway)
        {
            return railway;
        }
    }
}
