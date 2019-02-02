using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class ExperimentTypeRequest
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }
    }
}
