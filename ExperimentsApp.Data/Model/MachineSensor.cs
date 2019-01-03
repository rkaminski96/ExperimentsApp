using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class MachineSensor
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
