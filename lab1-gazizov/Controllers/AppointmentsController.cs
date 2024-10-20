
using Microsoft.AspNetCore.Mvc;
using lab1_gazizov.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1_gazizov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private static List<Appointment> appointments = new List<Appointment>();
        private static List<Barber> barbers = BarbersController.barbers;
        private static List<Customer> customers = CustomersController.customers;

        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAppointments()
        {
            return appointments;
        }

        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();
            return appointment;
        }

        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment appointment)
        {
            var barber = barbers.FirstOrDefault(b => b.Id == appointment.BarberId);
            if (barber == null)
                return NotFound("Парикмахер не найден.");

            var customer = customers.FirstOrDefault(c => c.Id == appointment.CustomerId);
            if (customer == null)
                return NotFound("Клиент не найден.");

            if (!barber.IsAvailable(appointment.AppointmentTime))
                return BadRequest("Парикмахер недоступен в выбранное время.");

            appointment.Id = appointments.Count + 1;
            appointments.Add(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, Appointment appointment)
        {
            var existingAppointment = appointments.FirstOrDefault(a => a.Id == id);
            if (existingAppointment == null)
                return NotFound();

            var barber = barbers.FirstOrDefault(b => b.Id == appointment.BarberId);
            if (barber == null)
                return NotFound("Парикмахер не найден.");

            if (!barber.IsAvailable(appointment.AppointmentTime))
                return BadRequest("Парикмахер недоступен в выбранное время.");

            existingAppointment.AppointmentTime = appointment.AppointmentTime;
            existingAppointment.BarberId = appointment.BarberId;
            existingAppointment.CustomerId = appointment.CustomerId;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();
            appointments.Remove(appointment);
            return NoContent();
        }
    }
}
