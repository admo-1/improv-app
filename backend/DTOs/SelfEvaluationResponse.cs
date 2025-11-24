namespace backend.DTOs
{
    public class SelfEvaluationResponse
    {
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}
