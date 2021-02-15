using Lab1_ED1__backup_.Models;
using Microsoft.AspNetCore.Http;
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
            return View(Singleton.Instance1.PlayerDList);
        }

        public IActionResult SLPlayerC()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SLPlayerC(IFormCollection collection)
        {
            try
            {
                var newPlayer = new Models.Player
                {
                    Club = collection["Club"],
                    LName = collection["LName"],
                    Name = collection["Name"],
                    Position = collection["Position"],
                    Pay = Convert.ToInt32(collection["Pay"]),
                    Compensation = Convert.ToInt32(collection["Compensation"])
                };
                Singleton.Instance.PlayerList.Add(newPlayer);
                return RedirectToAction(nameof(SLPlayer));
            }
            catch
            {

                return View();
            }
        }

        public IActionResult DLPlayerC()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DLPlayerC(IFormCollection collection)
        {
            try
            {
                var newPlayer = new Models.Player
                {
                    Club = collection["Club"],
                    LName = collection["LName"],
                    Name = collection["Name"],
                    Position = collection["Position"],
                    Pay = Convert.ToInt32(collection["Pay"]),
                    Compensation = Convert.ToInt32(collection["Compensation"])
                };
                Singleton.Instance1.PlayerDList.Push(newPlayer);
                return RedirectToAction(nameof(DLPlayer));
            }
            catch
            {

                return View();
            }
        }
    }
}
