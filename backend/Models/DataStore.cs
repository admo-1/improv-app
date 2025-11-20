using System.Text.Json;

namespace backend.Models
{
    public static class DataStore
    {
        private static readonly string FilePath = Path.Combine("Data", "members.json");

        public static List<Member> Load()
        {
            if (!File.Exists(FilePath)) return new List<Member>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
        }

        public static void Save(List<Member> members)
        {
            var json = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
