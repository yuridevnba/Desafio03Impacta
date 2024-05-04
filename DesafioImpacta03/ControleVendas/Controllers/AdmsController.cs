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

        public IActionResult Modal()
        {
           

            return View();
        }

        public IActionResult Escolha()
        {


            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirmed(string email, string senha)
        {
            //var adm = await _context.Adm.FirstOrDefaultAsync(a => a.Email == email && a.Senha == senha);

            string emaill = "admin@gmail.com";
            string senhaa = "123";

           if (email == emaill && senha == senhaa)
           {
                return RedirectToAction(nameof(Escolha));
            }
           else
           {
                return RedirectToAction(nameof(Modal));
            }
        }

        

        //[HttpGet()]
        //public IActionResult Cadastrar()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
       
        //public async Task<IActionResult> Cadastrar([Bind("AdmId,Email,Senha")] Adm funcionario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(funcionario);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(funcionario);
        //}

    }
}





