using System.ComponentModel.DataAnnotations;


namespace ExperimentsApp.Data.Dto
{
    public class UserRegistration
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Username cannot be less than 5 characters")]
        [MaxLength(15, ErrorMessage = "Username cannot be more than 15 characters")]
        public string Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Username cannot be less than 8 characters")]
        [MaxLength(15, ErrorMessage = "Username cannot be more than 15 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
