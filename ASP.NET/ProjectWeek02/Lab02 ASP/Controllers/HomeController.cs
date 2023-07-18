using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02_ASP.Controllers
{

    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string token = filterContext.HttpContext.Session["AuthToken"] as string;

            if (string.IsNullOrEmpty(token))
            {
                // Token is not present or empty, redirect to the login view
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Login" }));
            }
            else
            {
                // Validate the token's expiration
                var jwtToken = new JwtSecurityToken(token);
                var now = DateTime.UtcNow;

                if (jwtToken.ValidTo < now)
                {
                    // Token has expired, redirect to the login view
                    filterContext.Result = new RedirectToRouteResult(new
                        System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Login" }));
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }

    public class HomeController : Controller
    {
        private CoffeeDBDataContext db = new CoffeeDBDataContext();

        [ValidateToken]
        public ActionResult Index(string sortOrder)
        {

            // Define the sorting order
            ViewBag.TypeSortParam = string.IsNullOrEmpty(sortOrder) ? "desc" : "";

            // Retrieve the coffee items from the database and apply the sorting order
            List<Coffee> coffees;
            if (sortOrder == "desc")
            {
                coffees = db.Coffees.OrderByDescending(c => c.Type).ToList();
                ViewBag.TypeSortParam = "asc";
            }
            else
            {
                coffees = db.Coffees.OrderBy(c => c.Type).ToList();
                ViewBag.TypeSortParam = "desc";
            }

            return View(coffees);
        }

        [ValidateToken]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateToken]
        [HttpPost]
        public ActionResult Create(Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                // Add the new coffee item to the database
                db.Coffees.InsertOnSubmit(coffee);
                db.SubmitChanges();

                TempData["ToastrMessage"] = "Create success item " + coffee.CoffeeName;
                TempData["ToastrType"] = "success";
                return View();
            }

            return View(coffee);
        }

        [ValidateToken]
        public ActionResult Edit(int id)
        {
            // Retrieve the coffee item with the specified ID from the database
            Coffee coffee = db.Coffees.FirstOrDefault(c => c.Id == id);

            if (coffee != null)
            {
                return View(coffee);
            }

            return RedirectToAction("Index");
        }

        [ValidateToken]
        [HttpPost]
        public ActionResult Edit(Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                // Update the coffee item in the database
                db.Coffees.Attach(coffee);
                db.Refresh(RefreshMode.KeepCurrentValues, coffee);
                db.SubmitChanges();

                TempData["ToastrMessage"] = "Edit success item " + coffee.CoffeeName;
                TempData["ToastrType"] = "success";
                return RedirectToAction("Index");
            }

            return View(coffee);
        }


        [ValidateToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            // Retrieve the coffee item with the specified ID from the database
             Coffee coffee = db.Coffees.FirstOrDefault(c => c.Id == id);

            if (coffee != null)
            {
                // Delete the coffee item from the database
                db.Coffees.DeleteOnSubmit(coffee);
                db.SubmitChanges();
            }
            TempData["ToastrMessage"] = coffee.CoffeeName + " of " + coffee.Type + " type deleted";
            TempData["ToastrType"] = "warning";
            return RedirectToAction("index");
       
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}