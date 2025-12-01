using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AppreciationRequest
    {
        [Required]
        public int ToUserId { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Content { get; set; } = string.Empty;
    }
}
