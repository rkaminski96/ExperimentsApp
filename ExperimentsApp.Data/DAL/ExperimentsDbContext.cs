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
        public DbSet<MachineSensor> MachineSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {  
            builder.Entity<MachineSensor>().HasKey(ms => new { ms.MachineId, ms.SensorId });
            builder.Entity<Sensor>()
                .Property(b => b.sensorProperties)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));
        }
    }
}
