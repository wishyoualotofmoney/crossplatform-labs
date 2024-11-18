namespace lab1_gazizov.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreferredStyle { get; set; }
        public Appointment BookAppointment(DateTime time, Barber barber)
        {
            if (barber.IsAvailable(time))
            {
                return new Appointment
                {
                    Id = new Random().Next(1, 1000),
                    BarberId = barber.Id,
                    CustomerId = this.Id,
                    AppointmentTime = time
                };
            }
            else
            {
                throw new Exception("Парикмахер недоступен в выбранное время.");
            }
        }
    }
}
