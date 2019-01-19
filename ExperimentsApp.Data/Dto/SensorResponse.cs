using System.Collections.Generic;

namespace ExperimentsApp.Data.Dto
{
    public class SensorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public Dictionary<string, string> sensorProperties { get; set; } 
    }
}
