using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Appreciation
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; } = null!;

        public int TargetUserId { get; set; }
        public User TargetUser { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
