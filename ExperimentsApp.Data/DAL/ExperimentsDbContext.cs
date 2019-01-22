using Microsoft.EntityFrameworkCore;
using ExperimentsApp.Data.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExperimentsApp.Data.DAL
{
    public class ExperimentsDbContext : DbContext
    {
        public ExperimentsDbContext(DbContextOptions<ExperimentsDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentType> ExperimentTypes { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<ExperimentSensor> ExperimentSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {  
            builder.Entity<ExperimentSensor>().HasKey(es => new { es.ExperimentId, es.SensorId });
            builder.Entity<Sensor>()
                .Property(b => b.SensorProperties)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));
        }
    }
}
