namespace DeepBreaths.API.Models
{
    public class MoodEntry
    {
        public int Id { get; set; }
        public string Mood { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
