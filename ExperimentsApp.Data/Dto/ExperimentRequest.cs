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
    }
}
