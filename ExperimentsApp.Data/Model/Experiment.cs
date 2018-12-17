using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class Experiment
    {
        public int ExperimentId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        public int ExperimentTypeId { get; set; }
        public ExperimentType ExperimentType { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
