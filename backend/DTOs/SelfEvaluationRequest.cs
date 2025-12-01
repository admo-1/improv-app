using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class SelfEvaluationRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Content { get; set; } = string.Empty;
    }
}
