using System.Collections.Generic;

namespace ExperimentsApp.Data.Model
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public Dictionary<string, string> sensorProperties { get; set; } = new Dictionary<string, string>();

        public IList<MachineSensor> MachineSensors { get; set; }
    }
}
