using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAspMvc.Models;

namespace ProjetoAspMvc.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly Contexto _context;

        public NoticiasController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Noticia != null ? 
                          View(await _context.Noticia.ToListAsync()) :
                          Problem("Entity set 'Contexto.Noticia'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Noticia == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TituloNoticia")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Noticia == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TituloNoticia")] Noticia noticia)
        {
            if (id != noticia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(noticia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Noticia == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Noticia == null)
            {
                return Problem("Entity set 'Contexto.Noticia'  is null.");
            }
            var noticia = await _context.Noticia.FindAsync(id);
            if (noticia != null)
            {
                _context.Noticia.Remove(noticia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaExists(int id)
        {
          return (_context.Noticia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
