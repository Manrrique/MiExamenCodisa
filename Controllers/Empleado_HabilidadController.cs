using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EXAMEN.Data;
using EXAMEN.Models;

namespace EXAMEN.Controllers
{
    public class Empleado_HabilidadController : Controller
    {
        private readonly ExamenContext _context;

        public Empleado_HabilidadController(ExamenContext context)
        {
            _context = context;
        }

        // GET: Empleado_Habilidad
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["IdEmpleado"] = await _context.Empleado.Where(x => x.IdEmpleado == id).FirstOrDefaultAsync();
            var examenContext = _context.Empleado_Habilidad.Where(x => x.IdEmpleado == id);
            return View(await examenContext.ToListAsync());
        }

        // GET: Empleado_Habilidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado_Habilidad = await _context.Empleado_Habilidad
                .Include(e => e.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHabilidad == id);
            if (empleado_Habilidad == null)
            {
                return NotFound();
            }

            return View(empleado_Habilidad);
        }

        // GET: Empleado_Habilidad/Create
        public IActionResult Create(int id)
        {
            ViewData["IdEmpleado"] = _context.Empleado.Where(x => x.IdEmpleado == id).FirstOrDefault();
            return View();
        }

        // POST: Empleado_Habilidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabilidad,IdEmpleado,NombreHabilidad")] Empleado_Habilidad empleado_Habilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado_Habilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = empleado_Habilidad.IdEmpleado });
            }
            ViewData["IdEmpleado"] = await _context.Empleado.Where(x => x.IdEmpleado == empleado_Habilidad.IdEmpleado).FirstOrDefaultAsync();
            return View(empleado_Habilidad);
        }

        // GET: Empleado_Habilidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado_Habilidad = await _context.Empleado_Habilidad.FindAsync(id);
            if (empleado_Habilidad == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = await _context.Empleado.Where(x => x.IdEmpleado == empleado_Habilidad.IdEmpleado).FirstOrDefaultAsync();
            return View(empleado_Habilidad);
        }

        // POST: Empleado_Habilidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabilidad,IdEmpleado,NombreHabilidad")] Empleado_Habilidad empleado_Habilidad)
        {
            if (id != empleado_Habilidad.IdHabilidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado_Habilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Empleado_HabilidadExists(empleado_Habilidad.IdHabilidad))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = empleado_Habilidad.IdEmpleado });
            }
            ViewData["IdEmpleado"] = await _context.Empleado.Where(x => x.IdEmpleado == empleado_Habilidad.IdEmpleado).FirstOrDefaultAsync();
            return View(empleado_Habilidad);
        }

        // GET: Empleado_Habilidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado_Habilidad = await _context.Empleado_Habilidad
                .Include(e => e.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHabilidad == id);
            if (empleado_Habilidad == null)
            {
                return NotFound();
            }

            return View(empleado_Habilidad);
        }

        // POST: Empleado_Habilidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado_Habilidad = await _context.Empleado_Habilidad.FindAsync(id);
            _context.Empleado_Habilidad.Remove(empleado_Habilidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = id });
        }

        private bool Empleado_HabilidadExists(int id)
        {
            return _context.Empleado_Habilidad.Any(e => e.IdHabilidad == id);
        }
    }
}
