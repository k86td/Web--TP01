using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TP01.Infrastructure;
using TP01.Models;

namespace TP01.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly GuitaresDatabaseEntities DB = new GuitaresDatabaseEntities();
        // test
        // GET: Guitars
        public ActionResult Index()
        {
            return View(DB.Guitars.OrderBy(el => el.AddDate));
        }

        public ActionResult Details (int id)
        {
            Guitar search = DB.Guitars.Find(id);
            return View(search);
            
        }

        public ActionResult About ()
        {
            return View();
        }

        public ActionResult Delete (Guitar guitar)
        {
            DB.EnleverGuitar(guitar.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Creedit(int? id)
        {
            if (id.HasValue)
            {
                Guitar guitar = DB.Guitars.Find(id);
                if (guitar == null) { return PartialView("_error"); }
                return View(guitar);
            }
            else
            {
                return View(new Guitar());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creedit(Guitar guitar)
        {
            int? id = guitar.Id;
            if (id.HasValue)
            {
                if (ModelState.IsValid)
                {
                    DB.ModifierGuitar(guitar);
                }
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    DB.AjouterGuitar(guitar);
                }
                return RedirectToAction("Index");
            }
        }

        

        




    }
}