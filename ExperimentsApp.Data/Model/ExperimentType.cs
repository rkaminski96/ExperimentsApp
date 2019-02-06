using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExperimentsApp.Data.Model
{
    public class ExperimentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Experiment> Experiments { get; set; }
    }
}
