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
    public class ProdutosDaMandioculturaController : Controller
    {
        private readonly BancoDeDados _context;

        public ProdutosDaMandioculturaController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: ProdutosDaMandiocultura
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdutosDaMandiocultura.ToListAsync());
        }

        // GET: ProdutosDaMandiocultura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosDaMandiocultura = await _context.ProdutosDaMandiocultura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosDaMandiocultura == null)
            {
                return NotFound();
            }

            return View(produtosDaMandiocultura);
        }

        // GET: ProdutosDaMandiocultura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutosDaMandiocultura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDoProduto,Valor,QuantidadeProduzida,DataDeFabricacao,DataDeValidade")] ProdutosDaMandiocultura produtosDaMandiocultura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtosDaMandiocultura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtosDaMandiocultura);
        }

        // GET: ProdutosDaMandiocultura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosDaMandiocultura = await _context.ProdutosDaMandiocultura.FindAsync(id);
            if (produtosDaMandiocultura == null)
            {
                return NotFound();
            }
            return View(produtosDaMandiocultura);
        }

        // POST: ProdutosDaMandiocultura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDoProduto,Valor,QuantidadeProduzida,DataDeFabricacao,DataDeValidade")] ProdutosDaMandiocultura produtosDaMandiocultura)
        {
            if (id != produtosDaMandiocultura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosDaMandiocultura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosDaMandioculturaExists(produtosDaMandiocultura.Id))
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
            return View(produtosDaMandiocultura);
        }

        // GET: ProdutosDaMandiocultura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosDaMandiocultura = await _context.ProdutosDaMandiocultura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosDaMandiocultura == null)
            {
                return NotFound();
            }

            return View(produtosDaMandiocultura);
        }

        // POST: ProdutosDaMandiocultura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtosDaMandiocultura = await _context.ProdutosDaMandiocultura.FindAsync(id);
            _context.ProdutosDaMandiocultura.Remove(produtosDaMandiocultura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosDaMandioculturaExists(int id)
        {
            return _context.ProdutosDaMandiocultura.Any(e => e.Id == id);
        }
    }
}
