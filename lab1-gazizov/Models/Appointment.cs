namespace lab1_gazizov.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int CustomerId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int Duration { get; set; } // Длительность записи в минутах (30 или 60 минут)
    }
}
