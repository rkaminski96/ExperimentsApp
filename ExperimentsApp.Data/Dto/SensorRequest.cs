using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class SensorRequest
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Type { get; set; }

        [Required]
        [MinLength(5)]
        public string Position { get; set; }
    }
}
