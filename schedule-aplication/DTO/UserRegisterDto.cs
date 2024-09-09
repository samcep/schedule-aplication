using System.ComponentModel.DataAnnotations;

namespace schedule_aplication.DTO
{
    public class UserRegisterDto
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
