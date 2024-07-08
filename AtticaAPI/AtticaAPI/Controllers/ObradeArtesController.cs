using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtticaAPI.Data;
using AtticaAPI.Models;

namespace AtticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObradeArtesController : ControllerBase
    {
        private readonly AtticaAPIContext _context;

        public ObradeArtesController(AtticaAPIContext context)
        {
            _context = context;
        }

        // GET: api/ObradeArtes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObradeArte>>> GetObradeArtes()
        {
            return await _context.ObradeArte.ToListAsync();
        }

        // GET: api/ObradeArtes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObradeArte>> GetObradeArte(int id)
        {
            var obradeArte = await _context.ObradeArte.FindAsync(id);

            if (obradeArte == null)
            {
                return NotFound();
            }

            return obradeArte;
        }

        // PUT: api/ObradeArtes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObradeArte(int id, ObradeArte obradeArte)
        {
            if (id != obradeArte.Id)
            {
                return BadRequest();
            }

            _context.Entry(obradeArte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObradeArteExists(id))
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

        // POST: api/ObradeArtes
        [HttpPost]
        public async Task<ActionResult<ObradeArte>> PostObradeArte(ObradeArte obradeArte)
        {
            _context.ObradeArte.Add(obradeArte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObradeArte", new { id = obradeArte.Id }, obradeArte);
        }

        // DELETE: api/ObradeArtes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObradeArte(int id)
        {
            var obradeArte = await _context.ObradeArte.FindAsync(id);
            if (obradeArte == null)
            {
                return NotFound();
            }

            _context.ObradeArte.Remove(obradeArte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObradeArteExists(int id)
        {
            return _context.ObradeArte.Any(e => e.Id == id);
        }
    }
}
