using lab1_gazizov.Models;
using System;

namespace lab1_gazizov.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int CustomerId { get; set; }
        public DateTime AppointmentTime { get; set; }

        // Метод бизнес-логики: Переназначение времени записи
        public void Reschedule(DateTime newTime, Barber barber)
        {
            if (barber.IsAvailable(newTime))
            {
                AppointmentTime = newTime;
            }
            else
            {
                throw new Exception("Парикмахер недоступен в новое время.");
            }
        }
    }
}
