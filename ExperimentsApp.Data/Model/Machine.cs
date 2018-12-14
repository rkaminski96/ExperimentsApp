using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class Machine
    {
        public Guid MachineId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Experiment> Experiments { get; set; }

        public IList<MachineSensor> MachineSensors { get; set; }
    }
}
