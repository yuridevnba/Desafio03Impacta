using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleVendas.Data;
using ControleVendas.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ControleVendas.Controllers
{
    public class VendasController : Controller
    {
        private readonly ControleVendasContext _context;

        public VendasController(ControleVendasContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendas.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.VendasID == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        public IActionResult Modal()
        {
            return View();
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendasID,HoraVenda,produtos,quantidade,Preco")] Vendas vendas)
        {
            if (ModelState.IsValid)
            {
                
                var funcionarioId = HttpContext.Session.GetInt32("FuncionarioId");

                if (funcionarioId.HasValue)
                {
                    
                    var produtoExistente = await _context.Produto.FirstOrDefaultAsync(p => p.Nome == vendas.produtos);

                    if (produtoExistente != null)
                    {
                        vendas.produtos = produtoExistente.Nome;
                    }
                    else
                    {
                        return RedirectToAction("Modal", "Vendas");
                    }

                    
                    vendas.FuncionarioId = funcionarioId.Value;

                    _context.Add(vendas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                   
                    return RedirectToAction("Login", "Funcionarios");
                }
            }
            return View(vendas);
        }













        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas == null)
            {
                return NotFound();
            }
            return View(vendas);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendasID,HoraVenda,produtos,quantidade,Preco")] Vendas vendas)
        {
            if (id != vendas.VendasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendasExists(vendas.VendasID))
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
            return View(vendas);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.VendasID == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas != null)
            {
                _context.Vendas.Remove(vendas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasExists(int id)
        {
            return _context.Vendas.Any(e => e.VendasID == id);
        }
    }
}
