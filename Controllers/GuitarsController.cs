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


    }
}