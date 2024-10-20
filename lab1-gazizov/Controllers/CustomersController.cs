using lab1_gazizov.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace lab1_gazizov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public static List<Customer> customers = new List<Customer>();

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return customers;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            customer.Id = customers.Count + 1;
            customers.Add(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
                return NotFound();
            existingCustomer.Name = customer.Name;
            existingCustomer.PreferredStyle = customer.PreferredStyle;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            customers.Remove(customer);
            return NoContent();
        }
    }
}
