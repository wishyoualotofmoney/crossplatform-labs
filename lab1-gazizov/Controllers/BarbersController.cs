using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using lab1_gazizov.Models;
using lab1_gazizov.Data;
using Microsoft.AspNetCore.Authorization;

namespace lab1_gazizov.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly BarbershopContext _context;
        public BarbersController(BarbershopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Barber>> GetBarbers()
        {
            return _context.Barbers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Barber> GetBarber(int id)
        {
            var barber = _context.Barbers.FirstOrDefault(b => b.Id == id);
            if (barber == null)
                return NotFound();
            return barber;
        }

        [HttpPost]
        public ActionResult<Barber> CreateBarber(Barber barber)
        {
            _context.Barbers.Add(barber);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBarber), new { id = barber.Id }, barber);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBarber(int id, Barber barber)
        {
            var existingBarber = _context.Barbers.FirstOrDefault(b => b.Id == id);
            if (existingBarber == null)
                return NotFound();

            existingBarber.Name = barber.Name;
            existingBarber.ExperienceLevel = barber.ExperienceLevel;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBarber(int id)
        {
            var barber = _context.Barbers.FirstOrDefault(b => b.Id == id);
            if (barber == null)
                return NotFound();

            _context.Barbers.Remove(barber);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
