using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP01.Controllers
{
    public class GuitarsController : Controller
    {
        // GET: Guitars
        public ActionResult Index()
        {
            Models.Guitar[] test =  { new Models.Guitar() };

            return View(test);
        }
    }
}