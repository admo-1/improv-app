using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ChangePasswordRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string NewPassword { get; set; } = string.Empty;
    }
}
