using System.ComponentModel.DataAnnotations;

namespace AlaThuqk.DATA.DTOs.User
{
    public class RegisterForm{
        
        [Required] [Phone] public string? PhoneNumber { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public string? Name { get; set; }

        public int? OtpCode { get; set; }
    }
}