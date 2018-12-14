using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class ExperimentType
    {
        public Guid ExperimentTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Experiment> Experiments { get; set; }
    }
}
