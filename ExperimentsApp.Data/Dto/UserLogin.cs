using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class UserLogin
    {
        [Required]
        public string Username { get; set; }
    
        [Required]
        public string Password { get; set; }
    }
}
