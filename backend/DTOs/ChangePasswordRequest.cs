namespace backend.DTOs
{
    public class ChangePasswordRequest
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; } = string.Empty;
    }
}
