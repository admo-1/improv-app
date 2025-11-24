namespace backend.DTOs
{
    public class AppreciationRequest
    {
        public int ToUserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
