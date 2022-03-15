﻿using System;
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

         public ActionResult Create()
         {
            ViewBag.Conditions = SelectListItemConverter<Condition>.Convert(DB.Conditions.ToList());
            ViewBag.GuitarTypes = SelectListItemConverter<GuitarType>.Convert(DB.GuitarTypes.ToList());
            ViewBag.Sellers = SelectListItemConverter<Seller>.Convert(DB.Sellers.ToList(), false);
            return View(new Guitar());
         }

        [HttpPost]
        public ActionResult Create(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                DB.AjouterGuitar(guitar);
                return RedirectToAction("Index");
            }
            return View(guitar);
        }

        public ActionResult Edit(int id)
        {
            Guitar guitar = DB.Guitars.Find(id);
            if (guitar != null)
            {
                ViewBag.Conditions = SelectListItemConverter<Condition>.Convert(DB.Conditions.ToList());
                ViewBag.GuitarTypes = SelectListItemConverter<GuitarType>.Convert(DB.GuitarTypes.ToList());
                ViewBag.Sellers = SelectListItemConverter<Seller>.Convert(DB.Sellers.ToList(), false);
                return View(guitar);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Guitar newsPost)
        {
            if (ModelState.IsValid)
            {
                DB.ModifierGuitar(newsPost);
                return RedirectToAction("Index");
            }
            return View(newsPost);
        }
    }
}