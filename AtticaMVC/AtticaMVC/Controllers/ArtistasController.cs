using Microsoft.AspNetCore.Mvc;
using AtticaMVC.Models;
using System.Threading.Tasks;

namespace AtticaMVC.Controllers
{
    public class ArtistasController : Controller
    {
        private readonly ArtistaService _artistaService;

        public ArtistasController(ArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        public async Task<IActionResult> Index()
        {
            var artistas = await _artistaService.GetArtistasAsync();
            return View(artistas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var artista = await _artistaService.GetArtistaAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artista artista)
        {
            if (ModelState.IsValid)
            {
                await _artistaService.CreateArtistaAsync(artista);
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var artista = await _artistaService.GetArtistaAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artista artista)
        {
            if (id != artista.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _artistaService.UpdateArtistaAsync(id, artista);
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var artista = await _artistaService.GetArtistaAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _artistaService.DeleteArtistaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
