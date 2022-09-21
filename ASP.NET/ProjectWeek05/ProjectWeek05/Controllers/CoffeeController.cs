using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectWeek05.Controllers
{
    public class CoffeeController : Controller
    {
        //
        // GET: /Coffee/
        CoffeeDBDataContext _context = new CoffeeDBDataContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string rootPath = Server.MapPath("~/");
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string destFile = System.IO.Path.Combine(rootPath, "Assets\\images\\" + fileName);
                file.SaveAs(destFile);
            }
            return View();
        }

        public ActionResult ListCoffee()
        {
            var coffee = _context.Coffees.ToList();
            return Json(coffee, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                string rootPath = Server.MapPath("~/");
                string fileName = System.IO.Path.GetFileName(coffee.ImagePath);

                coffee.ImagePath = "images/" + fileName;
                _context.Coffees.InsertOnSubmit(coffee);
                _context.SubmitChanges();
            }
            return Json(coffee, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var coffee = _context.Coffees.ToList().Find(m => m.Id == id);
            if (coffee != null)
            {
                _context.Coffees.DeleteOnSubmit(coffee);
                _context.SubmitChanges();
            }
            return Json(coffee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            var coffee = _context.Coffees.ToList().Find(m => m.Id == id);

            string rootPath = Server.MapPath("~/");
            string fileName = System.IO.Path.GetFileName(coffee.ImagePath);
            string destFile = System.IO.Path.Combine(rootPath, "Assets\\images\\" + fileName);
            coffee.ImagePath = destFile;

            return Json(coffee, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                string rootPath = Server.MapPath("~/");
                string fileName = System.IO.Path.GetFileName(coffee.ImagePath);
                coffee.ImagePath = "images/" + fileName;

                Coffee mv = (from p in _context.Coffees
                              where p.Id == coffee.Id
                                  select p).SingleOrDefault();

                mv.CoffeeName = coffee.CoffeeName;
                mv.ImagePath = coffee.ImagePath;
                mv.Type = coffee.Type;
                mv.Price = coffee.Price;
                _context.SubmitChanges();

            }
            return Json(coffee, JsonRequestBehavior.AllowGet);
        }


    }

}