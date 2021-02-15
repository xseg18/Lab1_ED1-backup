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
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Lab1_ED1__backup_.Controllers
{
    public class DoubleController : Controller
    {
        private IHostingEnvironment Environment;
        public DoubleController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public static int i = 0;
        public static string SName = "";
        public static string SLName = "";
        public static string SClub = "";
        public static decimal SPay = 0;
        public static ELineales.DoublyList<Player> found = new ELineales.DoublyList<Player>();

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
        public ActionResult AddFile()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFile(IFormFile postedfile)
        {
            if(postedfile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string FileName = Path.GetFileName(postedfile.FileName);
                string FilePath = Path.Combine(path, FileName);
                using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                {

                }
            }
            return RedirectToAction(nameof(Index));
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
                SName = name;
                SLName = lname;
                
                return RedirectToAction(nameof(Index));
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
        void Searcher(Player p)
        {
            
            if (p.Name == SName && p.LName == SLName)
            {
                found.Add(p);
            }
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
                Singleton.Instance1.PlayerDList.Foreach(Searcher);
                void Searcher(Player p)
                {
                    if (p.Pay == pay)
                    {
                        found.Add(p);
                    }
                }
                return RedirectToAction(nameof(Index/*poner vista*/));
            }
            catch
            {

                return View();
            }
        }
    }
}
