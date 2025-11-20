namespace backend.Models
{
    public class Member
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string HighlightMessage { get; set; } = "";
        public List<Appreciation> Received { get; set; } = new();
    }
}
