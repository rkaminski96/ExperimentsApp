using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class MachineSensor
    {
        public Guid MachineId { get; set; }
        public Machine Machine { get; set; }

        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
