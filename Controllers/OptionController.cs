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
    public class OptionController : ControllerBase
    {
        private readonly DatabaseDbContext _context;

        public OptionController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        {
            return await _context.options.ToListAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> GetOption(int id)
        {
            var Option = await _context.options.FindAsync(id);

            if (Option == null)
            {
                return NotFound();
            }

            return Option;
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(int id, Option Option)
        {
            if (id != Option.Id)
            {
                return BadRequest();
            }

            _context.Entry(Option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(Option Option)
        {
            _context.options.Add(Option);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { id = Option.Id }, Option);
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Option>> DeleteOption(int id)
        {
            var Option = await _context.options.FindAsync(id);
            if (Option == null)
            {
                return NotFound();
            }

            _context.options.Remove(Option);
            await _context.SaveChangesAsync();

            return Option;
        }

        private bool OptionExists(int id)
        {
            return _context.options.Any(e => e.Id == id);
        }
    }
}
