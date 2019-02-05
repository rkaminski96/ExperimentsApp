using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class SensorRequest
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Type { get; set; }

        [Required]
        [MinLength(10)]
        public string Position { get; set; }

        [Display(Name = "Sensor Properties")]
        public Dictionary<string, string> SensorProperties { get; set; } 
    }
}
