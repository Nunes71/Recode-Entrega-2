using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class VendaDeArtesanatosController : Controller
    {
        private readonly BancoDeDados _context;

        public VendaDeArtesanatosController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: VendaDeArtesanatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.VendaDeArtesanatos.ToListAsync());
        }

        // GET: VendaDeArtesanatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaDeArtesanatos = await _context.VendaDeArtesanatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaDeArtesanatos == null)
            {
                return NotFound();
            }

            return View(vendaDeArtesanatos);
        }

        // GET: VendaDeArtesanatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendaDeArtesanatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDoProduto,Valor,QuantidadeProduzida")] VendaDeArtesanatos vendaDeArtesanatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendaDeArtesanatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendaDeArtesanatos);
        }

        // GET: VendaDeArtesanatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaDeArtesanatos = await _context.VendaDeArtesanatos.FindAsync(id);
            if (vendaDeArtesanatos == null)
            {
                return NotFound();
            }
            return View(vendaDeArtesanatos);
        }

        // POST: VendaDeArtesanatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDoProduto,Valor,QuantidadeProduzida")] VendaDeArtesanatos vendaDeArtesanatos)
        {
            if (id != vendaDeArtesanatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaDeArtesanatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaDeArtesanatosExists(vendaDeArtesanatos.Id))
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
            return View(vendaDeArtesanatos);
        }

        // GET: VendaDeArtesanatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaDeArtesanatos = await _context.VendaDeArtesanatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaDeArtesanatos == null)
            {
                return NotFound();
            }

            return View(vendaDeArtesanatos);
        }

        // POST: VendaDeArtesanatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendaDeArtesanatos = await _context.VendaDeArtesanatos.FindAsync(id);
            _context.VendaDeArtesanatos.Remove(vendaDeArtesanatos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaDeArtesanatosExists(int id)
        {
            return _context.VendaDeArtesanatos.Any(e => e.Id == id);
        }
    }
}
