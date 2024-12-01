namespace lab1_gazizov.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; } // Добавлено поле для привязки услуги
        public DateTime AppointmentTime { get; set; }
        public int Duration { get; set; }

       public Barber Barber { get; set; } 
       public Customer Customer { get; set; }
        public Service Service { get; set; } // Добавлена связь с услугой
    }
}
