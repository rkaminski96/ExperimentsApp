using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class Sensor
    {
        public Guid SensorId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }

        public IList<MachineSensor> MachineSensors { get; set; }
    }
}
