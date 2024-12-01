using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using lab1_gazizov.Data;
using lab1_gazizov.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace lab1_gazizov.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly BarbershopContext _context;
        public AppointmentsController(BarbershopContext context)
        {
            _context = context;
        }
        // Получить все записи
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAppointments()
        {
            var appointments = _context.Appointments
                .Include(a => a.Barber)   // Жадная загрузка данных о парикмахере
                .Include(a => a.Customer) // Жадная загрузка данных о клиенте
                .Include(a => a.Service)  // Жадная загрузка данных об услуге
                .ToList();

            return Ok(appointments);
        }

        // Получить запись по ID
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Barber)   // Жадная загрузка данных о парикмахере
                .Include(a => a.Customer) // Жадная загрузка данных о клиенте
                .Include(a => a.Service)  // Жадная загрузка данных об услуге
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        // Создать новую запись
        // Создать новую запись
        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment appointment)
        {
            var barber = _context.Barbers.FirstOrDefault(b => b.Id == appointment.BarberId);
            if (barber == null)
                return NotFound("Парикмахер не найден.");

            var customer = _context.Customers.FirstOrDefault(c => c.Id == appointment.CustomerId);
            if (customer == null)
                return NotFound("Клиент не найден.");

            var service = _context.Services.FirstOrDefault(s => s.Id == appointment.ServiceId);
            if (service == null)
                return NotFound("Услуга не найдена.");

            // Проверяем, доступен ли парикмахер в указанное время с учетом длительности услуги
            var overlappingAppointment = _context.Appointments
                .Where(a => a.BarberId == appointment.BarberId)
                .Any(a => a.AppointmentTime < appointment.AppointmentTime.AddMinutes(service.Duration) &&
                          appointment.AppointmentTime < a.AppointmentTime.AddMinutes(service.Duration));

            if (overlappingAppointment)
            {
                return BadRequest("Парикмахер уже занят в выбранное время.");
            }

            appointment.Duration = service.Duration; // Устанавливаем длительность на основе выбранной услуги

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }


        // Обновить существующую запись
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, Appointment appointment)
        {
            var existingAppointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (existingAppointment == null)
                return NotFound();

            var barber = _context.Barbers.FirstOrDefault(b => b.Id == appointment.BarberId);
            if (barber == null)
                return NotFound("Парикмахер не найден.");

            var service = _context.Services.FirstOrDefault(s => s.Id == appointment.ServiceId);
            if (service == null)
                return NotFound("Услуга не найдена.");

            var overlappingAppointment = _context.Appointments
                .Where(a => a.BarberId == appointment.BarberId && a.Id != id)
                .Any(a => a.AppointmentTime < appointment.AppointmentTime.AddMinutes(service.Duration) &&
                          appointment.AppointmentTime < a.AppointmentTime.AddMinutes(a.Service.Duration));

            if (overlappingAppointment)
            {
                return BadRequest("Парикмахер уже занят в выбранное время.");
            }

            existingAppointment.AppointmentTime = appointment.AppointmentTime;
            existingAppointment.BarberId = appointment.BarberId;
            existingAppointment.CustomerId = appointment.CustomerId;
            existingAppointment.ServiceId = appointment.ServiceId;

            _context.SaveChanges();
            return Ok(existingAppointment);
        }


        // Удалить запись по ID
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("customer/{customerId}/count")]
        public ActionResult<object> GetAppointmentCountForCustomer(int customerId)
        {
            // Находим клиента по ID
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound("Клиент не найден.");
            }

            // Подсчитываем количество записей для данного клиента
            var appointmentCount = _context.Appointments
                .Where(a => a.CustomerId == customerId)
                .Count();

            // Создаем объект с информацией о клиенте и количестве записей
            var result = new
            {
                CustomerName = customer.Name,
                AppointmentCount = appointmentCount
            };

            return Ok(result);
        }



        [HttpGet("barber/{barberId}/weekly-appointments")]
        public ActionResult<object> GetWeeklyAppointmentsForBarber(int barberId)
        {
            // Находим барбера по ID
            var barber = _context.Barbers.FirstOrDefault(b => b.Id == barberId);
            if (barber == null)
            {
                return NotFound("Парикмахер не найден.");
            }

            // Определяем текущую дату и дату через 7 дней
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);

            // Получаем все записи для данного барбера на следующую неделю
            var weeklyAppointments = _context.Appointments
            .Where(a => a.BarberId == barberId && a.AppointmentTime >= today && a.AppointmentTime <= nextWeek)
            .ToList()
            .Select(a => new
            {
                a.Id,
                a.AppointmentTime,
                a.Duration,
                CustomerName = _context.Customers.FirstOrDefault(c => c.Id == a.CustomerId)?.Name
            })
            .ToList();

            // Создаем объект с информацией о барбере и его записях
            var result = new
            {
                BarberName = barber.Name,
                WeeklyAppointments = weeklyAppointments
            };

            return Ok(result);
        }
    }

}



