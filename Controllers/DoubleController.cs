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
    public class DoubleController : Controller
    {
        public static int i = 0;
        // GET: DoubleController
        public ActionResult Index()
        {
            return View(Singleton.Instance1.PlayerDList);
        }

        // GET: DoubleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoubleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoubleController/Create
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
                Singleton.Instance1.PlayerDList.Push(newPlayer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: DoubleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoubleController/Edit/5
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

        // GET: DoubleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoubleController/Delete/5
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

        public ActionResult SearchN()
        {
            return View();
        }

        // POST: DoubleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchN(IFormCollection collection)
        {
            try
            {
                string name = ""; //poner lo de collections
                string lname = "";
                ELineales.DoublyList<Player> found = new ELineales.DoublyList<Player>();
                void Searcher(Player p)
                {
                    if (p.Name == name && p.LName == lname)
                    {
                        found.Add(p);
                    }
                }
                Singleton.Instance1.PlayerDList.Foreach(Searcher);
                return RedirectToAction(nameof(Index/*poner vista*/));
            }
            catch
            {

                return View();
            }
        }

        public ActionResult SearchC()
        {
            return View();
        }

        // POST: DoubleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchC(IFormCollection collection)
        {
            try
            {
                string club = ""; //poner lo de collections
                ELineales.DoublyList<Player> found = new ELineales.DoublyList<Player>();
                void Searcher(Player p)
                {
                    if (p.Club == club)
                    {
                        found.Add(p);
                    }
                }
                Singleton.Instance1.PlayerDList.Foreach(Searcher);
                return RedirectToAction(nameof(Index/*poner vista*/));
            }
            catch
            {

                return View();
            }
        }

        public ActionResult SearchP()
        {
            return View();
        }

        // POST: DoubleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchP(IFormCollection collection)
        {
            try
            {
                decimal? pay = 0; //poner lo de collections
                ELineales.DoublyList<Player> found = new ELineales.DoublyList<Player>();
                void Searcher(Player p)
                {
                    if (p.Pay == pay)
                    {
                        found.Add(p);
                    }
                }
                Singleton.Instance1.PlayerDList.Foreach(Searcher);
                return RedirectToAction(nameof(Index/*poner vista*/));
            }
            catch
            {

                return View();
            }
        }
    }
}
