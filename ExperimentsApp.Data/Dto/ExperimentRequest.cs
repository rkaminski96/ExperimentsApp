using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class ExperimentRequest
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Path { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }
    }
}
