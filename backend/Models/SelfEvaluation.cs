using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class SelfEvaluation
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string Content { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
