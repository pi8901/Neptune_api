using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neptune.Data;
using Neptune.Models;

/*namespace Neptune.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly DatabaseDbContext _context;

        public ParameterController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: api/Parameters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parameter>>> GetParameters()
        {
            return await _context.parameter.Include(c => c.scripts).Include(d => d.parameter_child).Include(e => e.options).ToListAsync();
        }

        // GET: api/Parameters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parameter>> GetParameter(int id)
        {
            var Parameter = await _context.parameter.Include(c => c.scripts).Include(d => d.parameter_child).Include(e => e.options).FirstOrDefaultAsync(c => c.Id == id);

            if (Parameter == null)
            {
                return NotFound();
            }

            return Parameter;
        }

        // PUT: api/Parameters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameter(int id, Parameter Parameter)
        {
            if (id != Parameter.Id)
            {
                return BadRequest();
            }

            _context.Entry(Parameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParameterExists(id))
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

        // POST: api/Parameters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Parameter>> PostParameter(Parameter Parameter)
        {
            _context.parameter.Add(Parameter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParameter", new { id = Parameter.Id }, Parameter);
        }

        // DELETE: api/Parameters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parameter>> DeleteParameter(int id)
        {
            var Parameter = await _context.parameter.FindAsync(id);
            if (Parameter == null)
            {
                return NotFound();
            }

            _context.parameter.Remove(Parameter);
            await _context.SaveChangesAsync();

            return Parameter;
        }

        private bool ParameterExists(int id)
        {
            return _context.parameter.Any(e => e.Id == id);
        }
    }
}*/
