using ExperimentsApp.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExperimentsApp.Data.DAL.Configurations
{ 
    internal class MachineSensorConfiguration : IEntityTypeConfiguration<MachineSensor>
    {
        public void Configure(EntityTypeBuilder<MachineSensor> builder)
        {
            builder.HasKey(ms => new { ms.MachineId, ms.SensorId });
        }
    }
}
