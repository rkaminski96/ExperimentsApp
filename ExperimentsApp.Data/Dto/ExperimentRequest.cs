using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class ExperimentRequest
    {
        [Required]
        [MinLength(5)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public int ExperimentTypeId { get; set; }
        public int MachineId { get; set; }
        public List<int> SensorList { get; set; }
    }
}
