using Microsoft.EntityFrameworkCore;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Data.DAL.Configurations;


namespace ExperimentsApp.Data.DAL
{
    public class ExperimentsDbContext : DbContext
    {
        public ExperimentsDbContext(DbContextOptions<ExperimentsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentType> ExperimentTypes { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MachineSensor> MachineSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MachineSensorConfiguration());
        }

    }
}
