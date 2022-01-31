using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VonatAdmin.Models;

namespace VonatAdmin
{
    class AdminRepository
    {
        private readonly AdminDbContext _context;

        public AdminRepository(string connectionString)
        {
            var optionBuilder = new DbContextOptionsBuilder<AdminDbContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionBuilder.UseMySql(connectionString, serverVersion);
            _context = new AdminDbContext(optionBuilder.Options);
            _context.Database.EnsureCreated();
        }

        public void AddCity(Cities city)
        {
            //nincs mág ellenőrzés, hogy van e az adatbázisban ilyen
            _context.cities.Add(city);
            _context.SaveChanges();
        }
        public void AddRailway(Railways railway)
        {
            //nincs mág ellenőrzés, hogy van e az adatbázisban ilyen
            _context.railways.Add(railway);
            _context.SaveChanges();
        }
    }
}
