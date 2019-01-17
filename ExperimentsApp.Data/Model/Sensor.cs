using System.Collections.Generic;

namespace ExperimentsApp.Data.Model
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public List<KeyValuePair<string, string>> kvSensor;

        public IList<MachineSensor> MachineSensors { get; set; }
    }
}
