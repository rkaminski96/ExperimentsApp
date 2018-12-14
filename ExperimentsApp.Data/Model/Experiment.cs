using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class Experiment
    {
        public Guid ExperimentId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        public Guid ExperimentTypeId { get; set; }
        public ExperimentType ExperimentType { get; set; }

        public Guid MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
