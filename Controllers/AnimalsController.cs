using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackIt.Models;

namespace TrackIt.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly Contexto _context;

        public AnimalsController(Contexto context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Animals.Include(a => a.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animals = await _context.Animals
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnimalsId == id);
            if (animals == null)
            {
                return NotFound();
            }

            return View(animals);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalsId,AnimalNome,AnimalRaca,AnimalTipo,AnimalCor,AnimalSexo,AnimalObservacao,AnimalFoto,AnimalDtDesaparecimento,AnimalDtEncontro,AnimalStatus,UsuarioId")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", animals.UsuarioId);
            return View(animals);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animals = await _context.Animals.FindAsync(id);
            if (animals == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", animals.UsuarioId);
            return View(animals);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalsId,AnimalNome,AnimalRaca,AnimalTipo,AnimalCor,AnimalSexo,AnimalObservacao,AnimalFoto,AnimalDtDesaparecimento,AnimalDtEncontro,AnimalStatus,UsuarioId")] Animals animals)
        {
            if (id != animals.AnimalsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalsExists(animals.AnimalsId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", animals.UsuarioId);
            return View(animals);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animals = await _context.Animals
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnimalsId == id);
            if (animals == null)
            {
                return NotFound();
            }

            return View(animals);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animals == null)
            {
                return Problem("Entity set 'Contexto.Animals'  is null.");
            }
            var animals = await _context.Animals.FindAsync(id);
            if (animals != null)
            {
                _context.Animals.Remove(animals);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalsExists(int id)
        {
          return (_context.Animals?.Any(e => e.AnimalsId == id)).GetValueOrDefault();
        }
    }
}
