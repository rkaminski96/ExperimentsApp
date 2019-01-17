using System.Collections.Generic;

namespace ExperimentsApp.Data.Model
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Experiment> Experiments { get; set; }

        public IList<MachineSensor> MachineSensors { get; set; }
    }
}
