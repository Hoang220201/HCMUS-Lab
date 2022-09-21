using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjectWeek02.Areas.Main.Models;

namespace ProjectWeek02.Areas.Main.Controllers
{
    public class HomeController : Controller
    {
        UserDBA udba = new UserDBA();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SignUp model)
        {
            var result = new AccountModel().Login(model.Email, model.Password);
            if (result && ModelState.IsValid)
            {
                ModelState.AddModelError("", "Account is exist.");
                return View(model);
            }
            else
                try
                {
                    if (ModelState.IsValid)
                    {
                        string res = udba.SignUp(model);
                        TempData["msg"] = res;
                    }
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.Message;
                }
            return RedirectToAction("Create", "Home", new { Area = "Main" });
        }

        public ActionResult Create(SignUp model)
        {
            return View();
        }
    }
}



