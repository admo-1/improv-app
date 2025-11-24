namespace backend.DTOs
{
    public class AppreciationResponse
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public string FromUserName { get; set; } = string.Empty;
        public int ToUserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}
