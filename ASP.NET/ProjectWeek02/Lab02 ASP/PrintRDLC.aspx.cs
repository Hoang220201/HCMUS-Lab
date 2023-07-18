using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab02_ASP
{
    public partial class PrintRDLC : System.Web.UI.Page
    {
        private CoffeeDBDataContext db = new CoffeeDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LocalReport rep = rptReportViewer.LocalReport;
                rep.ReportPath = "SalesReport.rdlc";
                ReportDataSource rds = new ReportDataSource();


                DataTable dt = new DataTable();
                List<OrderDetail> orderDetails = db.OrderDetails.ToList();

                // Logic to calculate the top selling items
                List<OrderDetail> topSellingItems = orderDetails
                    .GroupBy(od => od.CoffeeID)
                    .Select(g => new OrderDetail
                    {
                        CoffeeID = g.Key,
                        OrderID = g.Key,
                        Quantity = g.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(od => od.Quantity)
                    .Take(10)
                    .ToList();

                rds.Name = "CoffeeDBDataSet";
                rds.Value = topSellingItems;
                rep.DataSources.Add(rds);
            }

        }
    }
}