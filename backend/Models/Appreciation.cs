namespace backend.Models
{
    public class Appreciation
    {
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Message { get; set; } = "";
    }
}
