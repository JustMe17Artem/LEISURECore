using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLEISURE.Controllers
{
    public class Objects : Controller
    {
        //не совсем корректное именование контроллера (Не критично)

        // GET: Objects
        public ActionResult Index()
        {
            return View();
        }

        // GET: Objects/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Objects/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Objects/Create
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

        // GET: Objects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Objects/Edit/5
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

        // GET: Objects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Objects/Delete/5
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
