using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public required string PhoneNumber { get; set; } = string.Empty;

        public required string PasswordHash { get; set; } = string.Empty;

        public bool HasToChangePassword { get; set; } = true;

        public List<Appreciation> AuthoredAppreciations { get; set; } = new();

        public List<Appreciation> ReceivedAppreciations { get; set; } = new();

        public SelfEvaluation? SelfEvaluation { get; set; }
    }
}
