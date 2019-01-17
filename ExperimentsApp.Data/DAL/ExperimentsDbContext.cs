using Microsoft.EntityFrameworkCore;
using ExperimentsApp.Data.Model;

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
        }
    }
}
