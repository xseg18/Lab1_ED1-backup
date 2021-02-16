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
        public static string SName = "";
        public static string SLName = "";
        public static decimal? SPay = 0;
        public static string SClub = "";
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
                var DeletePlayer = Singleton.Instance.PlayerDList.Foreach(x => x.ID == id);
                int pos = Singleton.Instance.PlayerList.IndexOf(DeletePlayer);
                Singleton.Instance.PlayerList.RemoveAt(pos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View(Singleton.Instance3.PlayerDSearch);
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
                string name = collection["Name"]; 
                string lname = collection["LName"];
                SName = name;
                SLName = lname;
                if(Singleton.Instance3.PlayerDSearch.Count() > 0)
                {
                    Singleton.Instance3.PlayerDSearch.Clear();
                }
                Singleton.Instance1.PlayerDList.Foreach(SearcherN);
                return RedirectToAction(nameof(Search));
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
                string club = collection["Club"]; //poner lo de collections
                SClub = club;
                if (Singleton.Instance3.PlayerDSearch.Count() > 0)
                {
                    Singleton.Instance3.PlayerDSearch.Clear();
                }
                Singleton.Instance1.PlayerDList.Foreach(SearcherC);
                return RedirectToAction(nameof(Search));
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
                decimal? pay = Convert.ToDecimal(collection["Pay"]);
                SPay = pay;
                if (Singleton.Instance3.PlayerDSearch.Count() > 0)
                {
                    Singleton.Instance3.PlayerDSearch.Clear();
                }
                Singleton.Instance1.PlayerDList.Foreach(SearcherP);
                return RedirectToAction(nameof(Search));
            }
            catch
            {

                return View();
            }
        }

        public void SearcherN(Player p)
        {
            if(p.Name == SName && p.LName == SLName)
            {
                Singleton.Instance3.PlayerDSearch.Push(p);
            }
        }

        public void SearcherP(Player p)
        {
            if(p.Pay == SPay)
            {
                Singleton.Instance3.PlayerDSearch.Push(p);
            }
        }
        public void SearcherC(Player p)
        {
            if (p.Club == SClub)
            {
                Singleton.Instance3.PlayerDSearch.Push(p);
            }
        }
    }
}
