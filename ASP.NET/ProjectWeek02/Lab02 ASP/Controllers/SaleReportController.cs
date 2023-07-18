using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02_ASP.Models;
using Microsoft.Reporting.WebForms;


namespace Lab02_ASP.Controllers
{
    public class SaleReportController : Controller
    {
        private CoffeeDBDataContext db = new CoffeeDBDataContext();
        string strConString = "Data Source=DESKTOP-37M40PJ\\SQLEXPRESS;Initial Catalog=CoffeeDB;Integrated Security=True";
        List<OD> model = new List<OD>();

        [ValidateToken]
        public ActionResult SalesReport()
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT C.CoffeeName, SUM(OD.Quantity) AS 'Quantity'\r\nFROM [OrderDetails] as OD\r\nINNER JOIN Coffee AS C ON OD.CoffeeID = C.Id\r\nGROUP BY C.CoffeeName";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var details = new OD();
                    details.CoffeeName = rdr["CoffeeName"].ToString();
                    details.Quantity = Convert.ToInt32(rdr["Quantity"].ToString());
                    model.Add(details);
                }
                cn.Close();
            }
            return View(model);
        }


    }

}