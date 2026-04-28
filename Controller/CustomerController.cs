using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PipelineProject.Data;
using PipelineProject.Model;

namespace PipelineProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase{

        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer == null) return NotFound();

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomers), new {id = customer.Id}, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if(id != customer.Id) return BadRequest();

            _context.Entry(customer).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer == null) return NotFound();

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("ping")]
        public IActionResult PingTest()
        {
            return Ok(new 
            { 
                Message = "CI/CD Pipeline Başarıyla Çalışıyor!", 
                Version = "v1.0.1",
                Time = DateTime.UtcNow 
            });
        }
    
    }
}