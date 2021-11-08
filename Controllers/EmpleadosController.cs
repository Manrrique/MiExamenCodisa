using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EXAMEN.Data;
using EXAMEN.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EXAMEN.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ExamenContext _context;

        public EmpleadosController(ExamenContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var examenContext = _context.Empleado.Include(e => e.IdAreaNavigation).Include(e => e.IdJefeNavigation);
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "Nombre");
            return View(await examenContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int idArea)
        {
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "Nombre");
           
            var result = await _context.Empleado.Include(e => e.IdAreaNavigation).Include(e => e.IdJefeNavigation).Where(x => x.IdArea == idArea).ToListAsync();

            return View(result);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.IdAreaNavigation)
                .Include(e => e.IdJefeNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "Nombre");
            ViewData["IdJefe"] = new SelectList(_context.Empleado, "IdEmpleado", "NombreCompleto");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,NombreCompleto,Cedula,Correo,FechaNacimiento,FechaIngreso,IdJefe,IdArea,Foto")] Empleado empleado, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null)
                {
                    if (Foto.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            Foto.CopyTo(ms);
                            empleado.Foto = ms.ToArray();
                        }
                    }
                    else
                    {
                        empleado.Foto = new Byte[1];
                    }
                }
                else
                {
                    empleado.Foto = new Byte[1];
                }

                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "Nombre", empleado.IdArea);
            ViewData["IdJefe"] = new SelectList(_context.Empleado, "IdEmpleado", "NombreCompleto", empleado.IdJefe);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "Nombre", empleado.IdArea);
            ViewData["IdJefe"] = new SelectList(_context.Empleado, "IdEmpleado", "NombreCompleto", empleado.IdJefe);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,NombreCompleto,Cedula,Correo,FechaNacimiento,FechaIngreso,IdJefe,IdArea,Foto")] Empleado empleado, IFormFile Foto)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Foto != null)
                    {
                        if (Foto.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                Foto.CopyTo(ms);
                                empleado.Foto = ms.ToArray();
                            }
                        }
                        else
                        {
                            empleado.Foto = new Byte[1];
                        }
                    }
                    else
                    {
                        empleado.Foto = new Byte[1];
                    }

                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "Nombre", empleado.IdArea);
            ViewData["IdJefe"] = new SelectList(_context.Empleado, "IdEmpleado", "NombreCompleto", empleado.IdJefe);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.IdAreaNavigation)
                .Include(e => e.IdJefeNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.IdEmpleado == id);
        }

        public async Task<IActionResult> ArbolEmpleados()
        {
            var lstEmpleados = await _context.Empleado.ToListAsync();
            var jefes = lstEmpleados.Where(x => x.IdJefe == null).ToList();

            List<Empleado> list = new();

            foreach (var item in jefes)
            {
                list.AddRange(GetChild(lstEmpleados, item.IdEmpleado));
            }

            return View(list);
        }



        public List<Empleado> GetChild(List<Empleado> list, int id)
        {
            var locations = list.Where(x => x.IdJefe == id || x.IdEmpleado == id).ToList();

            var child = locations.AsEnumerable().Union(
                                        list.AsEnumerable().Where(x => x.IdJefe == id).SelectMany(y => GetChild(list, y.IdEmpleado))).ToList();

            child = child.Where(x => x.IdJefe == null).ToList();

            return child;
        }
    }
}
