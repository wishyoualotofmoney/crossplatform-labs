namespace lab1_gazizov.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperienceLevel { get; set; }

        // Метод бизнес-логики: Проверка доступности парикмахера
        public bool IsAvailable(DateTime time)
        {
            // Пример простой логики
            return time.Hour >= 9 && time.Hour <= 18;
        }
    }
}
