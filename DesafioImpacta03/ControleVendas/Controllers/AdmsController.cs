using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleVendas.Data;
using ControleVendas.Models;

namespace ControleVendas.Controllers
{
    public class AdmsController : Controller
    {
        private readonly ControleVendasContext _context;

        public AdmsController(ControleVendasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<string> Confirmed(string email, string senha)
        {
           var adm = await _context.Adm.FirstOrDefaultAsync(a => a.Email == email && a.Senha == senha);

           if (adm != null)
           {
                return "<h1>oioioo</h1>";
            }
           else
           {
               return "<h1>caralhodeuruim</h1>";
            }
        }

        

        [HttpGet()]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Cadastrar([Bind("AdmId,Email,Senha")] Adm funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

    }
}





