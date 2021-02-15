using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_ED1__backup_.Controllers
{
    public class DoubleController : Controller
    {
        // GET: DoubleController
        public ActionResult Index()
        {
            return View();
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
    }
}
