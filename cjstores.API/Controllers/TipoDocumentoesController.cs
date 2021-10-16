using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cjstores.API.Data;
using cjstores.API.Data.Entities;

namespace cjstores.API.Controllers
{
    public class TipoDocumentoesController : Controller
    {
        private readonly DataContext _context;

        public TipoDocumentoesController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoDocumentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocumentos.ToListAsync());
        }

        // GET: TipoDocumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id_TD == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_TD,Nombre_TD,Abreviatura")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_TD,Nombre_TD,Abreviatura")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id_TD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.Id_TD))
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
            return View(tipoDocumento);
        }

        // GET: TipoDocumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id_TD == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // POST: TipoDocumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDocumento = await _context.TipoDocumentos.FindAsync(id);
            _context.TipoDocumentos.Remove(tipoDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoExists(int id)
        {
            return _context.TipoDocumentos.Any(e => e.Id_TD == id);
        }
    }
}
