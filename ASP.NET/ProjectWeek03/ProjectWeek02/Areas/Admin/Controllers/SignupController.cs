using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjectWeek02.Areas.Admin.Models;

namespace ProjectWeek02.Areas.Admin.Controllers
{
    public class SignupController : Controller
    {
        AdminDBA adba = new AdminDBA();

        // GET: Admin/Signup
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SignUp model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
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
                        string res = adba.SignUp(model);
                        TempData["msg"] = res;
                    }
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.Message;
                }
            return RedirectToAction("Create", "Signup", new { Area = "Admin" });
        }

        public ActionResult Create(SignUp model)
        {
            return View();
        }
    }
}