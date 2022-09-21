using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWeek02.Areas.Main.Models;

namespace ProjectWeek02.Areas.Main.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.Email, model.Password);
            if (result && ModelState.IsValid)
                return RedirectToAction("TableResponsive", "Login", new { Area = "Main" });
            else
                ModelState.AddModelError("", "Email or Password is incorrect.");

            return View(model);
        }

        public ActionResult TableResponsive()
        {
            CompanyDBDataContext context = new CompanyDBDataContext();
            var ProductInfos = context.Products.ToList();
            return View(ProductInfos);
        }

    }
}