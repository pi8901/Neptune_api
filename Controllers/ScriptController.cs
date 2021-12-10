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
    public class ScriptController : ControllerBase
    {
        private readonly DatabaseDbContext _context;

        public ScriptController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: api/Scripts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Script>>> GetScripts()
        {
            return await _context.scripts.Include(c => c.user).Include(d => d.parameter).ThenInclude(e => e.options).Include(d => d.parameter).ThenInclude(e => e.parameter_child).ToListAsync();
        }

        // GET: api/Scripts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Script>> GetScript(int id)
        {
            var Script = await _context.scripts.Include(b => b.parameter).Include(c => c.user).FirstOrDefaultAsync(c => c.Id == id);

            if (Script == null)
            {
                return NotFound();
            }

            return Script;
        }

        // PUT: api/Scripts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScript(int id, Script script)
        {
            //_context.Entry(script).State = EntityState.Modified;
            //_context.AttachRange(script.parameter);
            Parameter[] param = new Parameter[script.parameter.Count()];
            param[0] = (this._context.parameter.SingleOrDefault(a => a.Id == script.parameter.ElementAt(0).Id));
            foreach( Parameter p in script.parameter)
            {
                System.Console.WriteLine("Damn: " +this._context.parameter.SingleOrDefault(a => a.Id == p.Id).title);
                param.Append(this._context.parameter.SingleOrDefault(a => a.Id == p.Id));
                System.Console.WriteLine("Aray. " + param.Length);
            }
            var artist = this._context.scripts.AsNoTracking().Include(a => a.parameter)
                .SingleOrDefault(a => a.Id == id);

                System.Console.WriteLine("Hello: " + p.title);
                artist.parameter.Add(p);
            
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptExists(id))
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

        // POST: api/Scripts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Script>> PostScript(Script Script)
        {
            _context.scripts.Add(Script);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScript", new { id = Script.Id }, Script);
        }

        // DELETE: api/Scripts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Script>> DeleteScript(int id)
        {
            var Script = await _context.scripts.FindAsync(id);
            if (Script == null)
            {
                return NotFound();
            }

            _context.scripts.Remove(Script);
            await _context.SaveChangesAsync();

            return Script;
        }

        private bool ScriptExists(int id)
        {
            return _context.scripts.Any(e => e.Id == id);
        }
    }
}
