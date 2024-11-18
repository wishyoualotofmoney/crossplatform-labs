namespace lab1_gazizov.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperienceLevel { get; set; }
        public bool IsAvailable(DateTime time)
        {
            return time.Hour >= 9 && time.Hour <= 18;
        }
    }
}
