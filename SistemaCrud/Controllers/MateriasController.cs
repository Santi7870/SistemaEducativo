using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCrud.Data;
using SistemaCrud.Models;

namespace SistemaCrud.Controllers
{
    [Authorize]
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MateriasController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
            => View(await _db.Materias.OrderBy(m => m.Nombre).ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Materia m)
        {
            if (!ModelState.IsValid) return View(m);
            _db.Materias.Add(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var m = await _db.Materias.FindAsync(id);
            if (m == null) return NotFound();
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Materia m)
        {
            if (id != m.Id) return BadRequest();
            if (!ModelState.IsValid) return View(m);
            _db.Update(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var m = await _db.Materias.FindAsync(id);
            if (m == null) return NotFound();
            return View(m);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var m = await _db.Materias.FindAsync(id);
            if (m == null) return NotFound();
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var m = await _db.Materias.FindAsync(id);
            if (m == null) return NotFound();
            _db.Materias.Remove(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
