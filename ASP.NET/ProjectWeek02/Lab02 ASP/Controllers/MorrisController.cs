using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02_ASP.Controllers
{
    public class MorrisController : Controller
    {
        // GET: Morris
        public ActionResult Index()
        {
            return View();
        }
    }
}