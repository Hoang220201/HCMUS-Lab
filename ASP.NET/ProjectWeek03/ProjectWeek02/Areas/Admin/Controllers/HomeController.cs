using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWeek02.Areas.Admin.Models;

namespace ProjectWeek02.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)
                return RedirectToAction("ListAccount", "Home", new { Area = "Admin" });
            else
                ModelState.AddModelError("", "UserName or Password is incorrect.");

            return View(model);
        }

        public ActionResult ListAccount()
        {
            CompanyDBDataContext context = new CompanyDBDataContext();
            var AccountInfos = context.Accounts.ToList();
            return View(AccountInfos);
        }
    }
}