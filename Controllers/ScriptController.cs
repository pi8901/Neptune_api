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
        public async Task<ActionResult<IEnumerable<Parameter>>> GetParameters()
        {
            var list =  await _context.scripts.ToListAsync();
            var ret = new List<Script_vm>();
            foreach (Script x in list)
            {
                var p = await GetScript(x.Id);
                ret.Add(p);
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
            x.parameter_available = await _context.scriptParameter.Where(m => m.script.Id == x.Id).Select(m => m.parameter).Include(m => m.parameter_child).ToListAsync();
            x.parameter_implemented = await _context.scriptParameter.Where(m => m.script.Id == x.Id && m.implemented == true).Select(m => m.parameter).Include(m => m.parameter_child).ToListAsync();

            if (Script == null)
            {
                return NotFound();
            }

            return x;
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
