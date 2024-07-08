using Microsoft.AspNetCore.Mvc;
using AtticaMVC.Models;
using System.Threading.Tasks;

namespace AtticaMVC.Controllers
{
    public class ObradeArtesController : Controller
    {
        private readonly ObradeArteService _obraService;

        public ObradeArtesController(ObradeArteService obraService)
        {
            _obraService = obraService;
        }

        public async Task<IActionResult> Index()
        {
            var obras = await _obraService.GetObrasAsync();
            return View(obras);
        }

        public async Task<IActionResult> Details(int id)
        {
            var obra = await _obraService.GetObraAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            return View(obra);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ObradeArte obra)
        {
            if (ModelState.IsValid)
            {
                await _obraService.CreateObraAsync(obra);
                return RedirectToAction(nameof(Index));
            }
            return View(obra);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var obra = await _obraService.GetObraAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            return View(obra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ObradeArte obra)
        {
            if (id != obra.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _obraService.UpdateObraAsync(id, obra);
                return RedirectToAction(nameof(Index));
            }
            return View(obra);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var obra = await _obraService.GetObraAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            return View(obra);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _obraService.DeleteObraAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
