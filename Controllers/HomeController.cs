using Lab1_ED1__backup_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab1_ED1__backup_.Models.Data;

namespace Lab1_ED1__backup_.Controllers
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
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create(string lista)
        {
            if (lista == "s")
            {
                return RedirectToAction(nameof(SLPlayer));
            }
            else
            {
                return RedirectToAction(nameof(DLPlayer));
            }
        }

        public IActionResult SLPlayer()
        {
            return View(Singleton.Instance.PlayerList);
        }

        public IActionResult DLPlayer()
        {
            return View();
        }
    }
}
