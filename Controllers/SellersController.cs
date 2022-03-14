using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using TP01.Models;
using TP01.Infrastructure;

namespace TP01.Controllers
{
    public class SellersController : Controller
    {
        private readonly GuitaresDatabaseEntities DB = new GuitaresDatabaseEntities();

        public ActionResult Index()
        {
            return View(DB.Sellers);
        }

        public ActionResult Create ()
        {
            return View(new Seller());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Seller seller)
        {
            if (ModelState.IsValid)
                DB.AjouterSeller(seller);
            else
                return View(seller);

            return RedirectToAction("Index");
        }

        public ActionResult Edit (int id)
        {
            Seller search = DB.Sellers.Find(id);
            if (search is null)
                return RedirectToAction("Index");

            return View(search);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Seller seller)
        {
            if (ModelState.IsValid)
                DB.ModifierSeller(seller);
            else
                return View(seller);

            return RedirectToAction("Index");
        }
    }
}