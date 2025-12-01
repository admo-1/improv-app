namespace backend.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public bool HasToChangePassword { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
