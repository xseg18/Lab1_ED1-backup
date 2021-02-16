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
            var ViewPlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
            return View(ViewPlayer);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var EditPlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
                int pos = Singleton.Instance.PlayerList.IndexOf(EditPlayer);
                Singleton.Instance.PlayerList[pos].Club = collection["Club"];
                Singleton.Instance.PlayerList[pos].Pay = Convert.ToInt32(collection["Pay"]);
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
            var ViewPlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
            return View(ViewPlayer);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var DeletePlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
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
            return View(Singleton.Instance2.PlayerSearch);
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
                Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Name == name && x.LName == lname);
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
                string club = collection["Club"];
                Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Club == club);
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
        public ActionResult SearchP(string salario, IFormCollection collection)
        {
            try
            {
                int pay = Convert.ToInt32(collection["Pay"]);
                if (salario == "menor")
                {
                    Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Pay <= pay);
                }
                else if (salario == "igual")
                {
                    Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Pay == pay);
                }
                else
                {
                    Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Pay >= pay);
                }
                return RedirectToAction(nameof(Search));
            }
            catch
            {

                return View();
            }
        }
    }
}
