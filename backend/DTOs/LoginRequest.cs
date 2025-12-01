using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class LoginRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; } = string.Empty;
    }
}
