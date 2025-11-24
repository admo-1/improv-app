namespace backend.DTOs
{
    public class SelfEvaluationRequest
    {
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
