using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtticaAPI.Data;
using AtticaAPI.Models;

namespace AtticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        private readonly AtticaAPIContext _context;

        public ArtistasController(AtticaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Artistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistas()
        {
            return await _context.Artista.ToListAsync();
        }

        // GET: api/Artistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
            var artista = await _context.Artista.FindAsync(id);

            if (artista == null)
            {
                return NotFound();
            }

            return artista;
        }

        // PUT: api/Artistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtista(int id, Artista artista)
        {
            if (id != artista.Id)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExists(id))
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

        // POST: api/Artistas
        [HttpPost]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
            _context.Artista.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtista", new { id = artista.Id }, artista);
        }

        // DELETE: api/Artistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtista(int id)
        {
            var artista = await _context.Artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artista.Remove(artista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistaExists(int id)
        {
            return _context.Artista.Any(e => e.Id == id);
        }
    }
}
