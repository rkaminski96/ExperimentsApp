using ExperimentsApp.Data.Model;
using System;
using System.Collections.Generic;

namespace ExperimentsApp.Data.Dto
{
    public class ExperimentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set;  }
        public DateTime CreationDateTime { get; set; } 
        public string Description { get; set; }

        public int ExperimentTypeId { get; set; }

        public int MachineId { get; set; }
    }
}
