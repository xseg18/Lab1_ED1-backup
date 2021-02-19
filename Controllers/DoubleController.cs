using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Lab1_ED1__backup_.Models;
using Lab1_ED1__backup_.Models.Data;

namespace Lab1_ED1__backup_.Controllers
{
    public class DoubleController : Controller
    {
        public static int i = 0;
        public static string log = "";
        Stopwatch stopWatch = new Stopwatch();
        public static string SName = "";
        public static string SLName = "";
        public static decimal? SPay = 0;
        public static string SClub = "";
        public static int Id = 0;
        public static Player IDFinder = new Player();
        public static string PayFinder = "";

        // GET: DoubleController
        private IHostingEnvironment Environment;

        public DoubleController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public ActionResult Index()
        {
            return View(Singleton.Instance1.PlayerDList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormFile postedFile)
        {
            stopWatch.Reset();
            stopWatch.Start();
            string Club = "", LName = "", Name = "", Position = "";
            Decimal Salary = 0, Compensation = 0;
            if (postedFile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {
                                firstRow = false;
                            }
                            else
                            {
                                int y = 0;
                                foreach (string cell in row.Split(','))
                                {
                                    if (y == 0)
                                    {
                                        Club = cell.Trim();
                                        y++;
                                    }
                                    else if (y == 1)
                                    {
                                        LName = cell.Trim();
                                        y++;
                                    }
                                    else if (y == 2)
                                    {
                                        Name = cell.Trim();
                                        y++;
                                    }
                                    else if (y == 3)
                                    {
                                        Position = cell.Trim();
                                        y++;
                                    }
                                    else if (y == 4)
                                    {
                                        Salary = Convert.ToDecimal(cell.Trim());
                                        y++;
                                    }
                                    else
                                    {
                                        Compensation = Convert.ToDecimal(cell.Trim());
                                        var newPlayer = new Player
                                        {
                                            Club = Club,
                                            LName = LName,
                                            Name = Name,
                                            Position = Position,
                                            Pay = Salary,
                                            Compensation = Compensation,
                                            ID = i++
                                        };
                                        Singleton.Instance1.PlayerDList.Push(newPlayer);
                                    }
                                }
                            }
                        }
                    }
                }
                stopWatch.Stop();
                log += "[CSV Upload] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return View(Singleton._instance1.PlayerDList);
            }
            stopWatch.Stop();
            return View(Singleton._instance1.PlayerDList);
        }

        // GET: DoubleController/Details/5
        public ActionResult Details(int id)
        {
            stopWatch.Reset();
            stopWatch.Start();
            Id = id;
            Singleton.Instance1.PlayerDList.Foreach(SearcherID);
            stopWatch.Stop();
            log += "[Details] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
            return View(IDFinder);
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
            stopWatch.Reset();
            stopWatch.Start();
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
                stopWatch.Stop();
                log += "[Create] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                stopWatch.Stop();
                return View();
            }
        }

        // GET: DoubleController/Edit/5
        public ActionResult Edit(int id)
        {
            Id = id;
            Singleton.Instance1.PlayerDList.Foreach(SearcherID);
            return View(IDFinder);
        }

        // POST: DoubleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                Id = id;
                Singleton.Instance1.PlayerDList.Foreach(SearcherID);
                int pos = Singleton.Instance1.PlayerDList.IndexOf(IDFinder);
                Singleton.Instance1.PlayerDList[pos].Club = collection["Club"];
                Singleton.Instance1.PlayerDList[pos].Pay = Convert.ToInt32(collection["Pay"]);
                stopWatch.Stop();
                log += "[Edit] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                stopWatch.Stop();
                return View();
            }
        }

        // GET: DoubleController/Delete/5
        public ActionResult Delete(int id)
        {
            Id = id;
            Singleton.Instance1.PlayerDList.Foreach(SearcherID);
            return View(IDFinder);
        }

        // POST: DoubleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                Id = id;
                Singleton.Instance1.PlayerDList.Foreach(SearcherID);
                Singleton.Instance1.PlayerDList.Delete(IDFinder);
                stopWatch.Stop();
                log += "[Delete] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                stopWatch.Stop();
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
            stopWatch.Reset();
            stopWatch.Start();
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
                stopWatch.Stop();
                log += "[Search N] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                stopWatch.Stop();
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
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                string club = collection["Club"]; //poner lo de collections
                SClub = club;
                if (Singleton.Instance3.PlayerDSearch.Count() > 0)
                {
                    Singleton.Instance3.PlayerDSearch.Clear();
                }
                Singleton.Instance1.PlayerDList.Foreach(SearcherC);
                stopWatch.Stop();
                log += "[Search C] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                stopWatch.Stop();
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
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                decimal? pay = Convert.ToDecimal(collection["Pay"]);
                SPay = pay;
                PayFinder = salario;
                if (Singleton.Instance3.PlayerDSearch.Count() > 0)
                {
                    Singleton.Instance3.PlayerDSearch.Clear();
                }
                Singleton.Instance1.PlayerDList.Foreach(SearcherP);
                stopWatch.Stop();
                log += "[Search P] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                stopWatch.Stop();
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
            if (PayFinder == "igual")
            {
                if (p.Pay == SPay)
                {
                    Singleton.Instance3.PlayerDSearch.Push(p);
                }
            }
            else if(PayFinder == "mayor")
            {
                if (p.Pay > SPay)
                {
                    Singleton.Instance3.PlayerDSearch.Push(p);
                }
            }
            else
            {
                if (p.Pay < SPay)
                {
                    Singleton.Instance3.PlayerDSearch.Push(p);
                }
            }
        }

        public void SearcherC(Player p)
        {
            if (p.Club == SClub)
            {
                Singleton.Instance3.PlayerDSearch.Push(p);
            }
        }

        public void SearcherID(Player p)
        {
            if(p.ID == Id)
            {
                IDFinder = p;
            }
        }

        public ActionResult Log()
        {
            StreamWriter writer = new StreamWriter("Log_File.txt");
            writer.Write(log);
            writer.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
