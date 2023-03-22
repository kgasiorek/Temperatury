using Domain.SettingsEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class SettingsContext : DbContext
    {
        public DbSet<SensorSettings> SensorSettings { get; set; }
        public DbSet<ApplicationSettings> ApplicationSettings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TypeOfSensor> TypesOfSensor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Db/Settings.db");
        }
    }
}
