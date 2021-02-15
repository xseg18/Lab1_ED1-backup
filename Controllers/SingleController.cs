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
    public class SingleController : Controller
    {
        public static int i = 0;
        // GET: HomeController1
        public ActionResult Index()
        {
            return View(Singleton._instance.PlayerList);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var ViewPlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
            return View(ViewPlayer);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
                    Compensation = Convert.ToInt32(collection["Compensation"]),
                    ID = i++
                };
                Singleton.Instance.PlayerList.Add(newPlayer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
