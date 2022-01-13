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
        public async Task<ActionResult<IEnumerable<Script_vm>>> GetScripts()
        {
            var list =  await _context.scripts.Include(c => c.user).ToListAsync();
            var ret = new List<Script_vm>();
            foreach (Script Script in list)
            {
                var x = new Script_vm();
                x.Id = Script.Id;
                x.title = Script.title;
                x.user = Script.user;
                x.description = Script.description;
                x.type = Script.type;
                x.parameter_available = await _context.scriptParameter.Where(m => m.script.Id == x.Id).Include(m => m.parameter.options).Include(m => m.parameter.parameter_child).Select(m => m.parameter).ToListAsync();
                x.parameter_implemented = await _context.scriptParameter.Where(m => m.script.Id == x.Id && m.implemented == true).Include(m => m.parameter.options).Include(m => m.parameter.parameter_child).Select(m => m.parameter).ToListAsync();
                ret.Add(x);
            }
            return ret;
        }


        // GET: api/Scripts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Script_vm>> GetScript(int id)
        {
            var x = new Script_vm();
            var Script = await _context.scripts.Include(b => b.parameter).Include(c => c.user).FirstOrDefaultAsync(c => c.Id == id);
            x.Id = Script.Id;
            x.title = Script.title;
            x.user = Script.user;
            x.description = Script.description;
            x.type = Script.type;
            x.parameter_available = await _context.scriptParameter.Where(m => m.script.Id == x.Id).Select(m => m.parameter).ToListAsync();
            x.parameter_implemented = await _context.scriptParameter.Where(m => m.script.Id == x.Id && m.implemented == true).Select(m => m.parameter).ToListAsync();

            if (Script == null)
            {
                return NotFound();
            }

            return x;
        }

        // PUT: api/Parameters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScript(int id, Script_vm Script)
        {
            System.Console.WriteLine("Got Here");
            if (id != Script.Id)
            {
                return BadRequest();
            }
            Script s = _context.scripts.Where(d => d.Id == Script.Id).FirstOrDefault();
            s.title = Script.title;
            s.description = Script.description;
            s.type = Script.type;
            
            User user = _context.user.Where(u => u.username == Script.user.username).FirstOrDefault();
            s.user = user;

            foreach (Parameter p in Script.parameter_available)
            {
                ScriptParameter sp = _context.scriptParameter.Where(sp => sp.script.Id == Script.Id && sp.parameter.Id == p.Id).FirstOrDefault();
                sp.implemented = false;
            }

            foreach (Parameter p in Script.parameter_implemented)
            {
                ScriptParameter sp = _context.scriptParameter.Where(sp => sp.script.Id == Script.Id && sp.parameter.Id == p.Id).FirstOrDefault();
                sp.implemented = true;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        // POST: api/Scripts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Script>> PostScript(Script Script)
        {
            System.Console.WriteLine("got to add");
            User u = await this._context.user.FirstOrDefaultAsync();
            Script.user = u;
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
