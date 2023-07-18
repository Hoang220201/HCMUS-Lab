using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Lab02_ASP.Models;


namespace Lab02_ASP.Controllers
{

    public class TableController : Controller
    {
        private CoffeeDBDataContext db = new CoffeeDBDataContext();
        string strConString = "Data Source=DESKTOP-37M40PJ\\SQLEXPRESS;Initial Catalog=CoffeeDB;Integrated Security=True";
        List<OD> model = new List<OD>();

        private const int PageSize = 10;

        [ValidateToken]
        public ActionResult Index(int page = 1)
        {
            List<Order> orders = db.Orders.OrderByDescending(c => c.Id).ToList();
            PagedList<Order> pagedOrders = new PagedList<Order>(orders, page, PageSize);
            return View(pagedOrders);
        }


        [ValidateToken]
        public ActionResult Detail(int id)
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT C.CoffeeName, C.[Type], OD.Quantity , (OD.Quantity*C.Price) AS 'Total Price'\r\nFROM [OrderDetails] as OD\r\nINNER JOIN Coffee AS C ON OD.CoffeeID = C.Id\r\nWHERE OD.OrderID = "+ id;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var details = new OD();
                    details.CoffeeName = rdr["CoffeeName"].ToString();
                    details.Quantity = Convert.ToInt32(rdr["Quantity"].ToString());
                    details.Price = Convert.ToInt32(rdr["Total Price"].ToString());
                    details.Type = rdr["Type"].ToString();
                    model.Add(details);
                }
                cn.Close();
            }
            ViewBag.Message = id;
            return View(model);
        }


        [ValidateToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            // Retrieve the coffee item with the specified ID from the database
            Order order = db.Orders.FirstOrDefault(c => c.Id == id); 
            var od = db.OrderDetails.ToList().FindAll(c => c.OrderID == id);

            if (order != null)
            {
                // Delete the coffee item from the database
                db.OrderDetails.DeleteAllOnSubmit(od);
                db.Orders.DeleteOnSubmit(order);
                db.SubmitChanges();

                TempData["ToastrMessage"] = "Order Id: " + order.Id + " deleted";
                TempData["ToastrType"] = "warning";
                return RedirectToAction("index");
            }
            TempData["ToastrMessage"] = "Something went wrong";
            TempData["ToastrType"] = "error";
            return RedirectToAction("index");

        }
    }

}