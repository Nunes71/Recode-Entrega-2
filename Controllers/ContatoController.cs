using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;

        public ContatoController(ILogger<ContatoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Contato()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}