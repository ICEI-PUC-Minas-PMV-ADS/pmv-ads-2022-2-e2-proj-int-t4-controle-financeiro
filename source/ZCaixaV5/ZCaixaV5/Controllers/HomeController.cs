
using Aspnet_AuthCookies1.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZCaixaV5.Models;

namespace Aspnet_AuthCookies1.Controllers
{
    namespace ZCaixaV5.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
                string usr;
                bool autenticado;
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    usr = HttpContext.User.Identity.Name;
                    autenticado = true;
                }
                else
                {
                    usr = "Não Logado";
                    autenticado = false;
                }

                ViewBag.usr = usr;
                ViewBag.autenticado = autenticado;
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }


    }
}
