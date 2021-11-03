using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neptune.Data;
using Neptune.Models;

namespace Neptune.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DatabaseDbContext _context;

        public TestController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {
            return await _context.test.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Test>> GetTest(string Id)
        {
            var contact = await _context.test.FindAsync(Id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutContact(int Id, Test contact)
        {
            if (Id != contact.Id)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Test>> PostContact(Test contact)
        {
            _context.test.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { Id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Test>> DeleteContact(int Id)
        {
            var contact = await _context.test.FindAsync(Id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.test.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        private bool ContactExists(int Id)
        {
            return _context.test.Any(e => e.Id == Id);
        }
    }
}
