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
    public class SingleController : Controller
    {
        public static int i = 0;
        public static string log = "";
        Stopwatch stopWatch = new Stopwatch();
        // GET: HomeController1
        private IHostingEnvironment Environment;

        public SingleController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public ActionResult Index()
        {
            return View(Singleton._instance.PlayerList);
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
                                        Singleton.Instance.PlayerList.Add(newPlayer);
                                    }
                                }
                            }
                        }
                    }
                }
                stopWatch.Stop();
                log += "[CSV Upload] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
                return View(Singleton._instance.PlayerList);
            }
            stopWatch.Stop();
            return View(Singleton._instance.PlayerList);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            stopWatch.Reset();
            stopWatch.Start();
            var ViewPlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
            stopWatch.Stop();
            log += "[Details] - " + Convert.ToString(stopWatch.Elapsed) + '\n';
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
                Singleton.Instance.PlayerList.Add(newPlayer);
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
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                var EditPlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
                int pos = Singleton.Instance.PlayerList.IndexOf(EditPlayer);
                Singleton.Instance.PlayerList[pos].Club = collection["Club"];
                Singleton.Instance.PlayerList[pos].Pay = Convert.ToInt32(collection["Pay"]);
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
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                var DeletePlayer = Singleton.Instance.PlayerList.Find(x => x.ID == id);
                int pos = Singleton.Instance.PlayerList.IndexOf(DeletePlayer);
                Singleton.Instance.PlayerList.RemoveAt(pos);
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
            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                string name = collection["Name"];
                string lname = collection["LName"];
                Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Name == name && x.LName == lname);
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
                string club = collection["Club"];
                Singleton.Instance2.PlayerSearch = Singleton.Instance.PlayerList.FindAll(x => x.Club == club);
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
                decimal? pay = Convert.ToInt32(collection["Pay"]);
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

        public ActionResult Log()
        {
            StreamWriter writer = new StreamWriter("Log_File.txt");
            writer.Write(log);
            writer.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
