using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace schedule_aplication.DTO
{
    public class UserRegisterDto
    {

        [Required]

        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage = "the password confirmation do not match")]
        public string ConfirmPassword { get; set; }
    }
}
