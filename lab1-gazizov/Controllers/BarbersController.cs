
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using lab1_gazizov.Models;

namespace lab1_gazizov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        public static List<Barber> barbers = new List<Barber>();

        [HttpGet]
        public ActionResult<IEnumerable<Barber>> GetBarbers()
        {
            return barbers;
        }

        [HttpGet("{id}")]
        public ActionResult<Barber> GetBarber(int id)
        {
            var barber = barbers.FirstOrDefault(b => b.Id == id);
            if (barber == null)
                return NotFound();
            return barber;
        }

        [HttpPost]
        public ActionResult<Barber> CreateBarber(Barber barber)
        {
            barber.Id = barbers.Count + 1;
            barbers.Add(barber);
            return CreatedAtAction(nameof(GetBarber), new { id = barber.Id }, barber);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBarber(int id, Barber barber)
        {
            var existingBarber = barbers.FirstOrDefault(b => b.Id == id);
            if (existingBarber == null)
                return NotFound();
            existingBarber.Name = barber.Name;
            existingBarber.ExperienceLevel = barber.ExperienceLevel;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBarber(int id)
        {
            var barber = barbers.FirstOrDefault(b => b.Id == id);
            if (barber == null)
                return NotFound();
            barbers.Remove(barber);
            return NoContent();
        }
    }
}
