using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperimentsApp.Data.Model
{
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        [ForeignKey("ExperimentType")]
        public int ExperimentTypeId { get; set; }
        public ExperimentType ExperimentType { get; set; }

        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
