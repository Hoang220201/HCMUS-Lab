using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Data;
using WeekProject04.Models;

namespace WeekProject04.Controllers
{
    public class HomeController : Controller
    {
        private List<EmployeesModel> EmployeesList = new List<EmployeesModel>();
        string xmlFilePath = "~/XMLfile/EmployeeData.xml";

        
        public List<EmployeesModel> ReadXMLData(string filepath)
        {
            string xmldata = Server.MapPath(filepath);
            DataSet ds = new DataSet();
            ds.ReadXml(xmldata);

            var employeelist = new List<EmployeesModel>();
            employeelist = (from rows in ds.Tables[0].AsEnumerable()
                            
                            select new EmployeesModel
                            {
                                EmployeeID = Convert.ToInt32(rows[0].ToString()),
                                EmployeeName = rows[1].ToString(),
                                Email = rows[2].ToString(),
                                Age = DateTime.Today.Year - (Convert.ToDateTime(rows[3].ToString()).Year),
                                Birthday = Convert.ToDateTime(rows[3].ToString()),
                                Type = rows[4].ToString()
                                
                            }).ToList();
            return employeelist;
        } 

        public void CreateXmlFile(string filepath, List<EmployeesModel> xmldata)
        {
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineOnAttributes = true
                };

                using (XmlWriter xmlwriter = XmlWriter.Create(Server.MapPath(filepath), xmlWriterSettings))
                {
                    xmlwriter.WriteStartDocument();
                    xmlwriter.WriteStartElement("Employee");
                    foreach (EmployeesModel e in xmldata)
                    {
                        xmlwriter.WriteStartElement("Employee");
                        xmlwriter.WriteElementString("EmployeeID", e.EmployeeID.ToString());
                        xmlwriter.WriteElementString("EmployeeName", e.EmployeeName.ToString());
                        xmlwriter.WriteElementString("Email", e.Email.ToString());
                        xmlwriter.WriteElementString("Birthday", e.Birthday.ToString());
                        xmlwriter.WriteElementString("Type", e.Type.ToString());
                        xmlwriter.WriteEndElement();
                    }
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndDocument();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Exception of type: " + ex + " occured please try again";
            }
        }

        public ActionResult Index(FormCollection searchdata)
        {
            ViewBag.Msg = "Employee XML Data";
            EmployeesList = ReadXMLData(xmlFilePath);

            if (searchdata["EmpNameSearch"] != null)
                EmployeesList = EmployeesList.Where(x => x.EmployeeName.Contains(searchdata["EmpNameSearch"])).ToList();
            if(searchdata["EmailSearch"] != null)
                EmployeesList = EmployeesList.Where(x => x.Email.Contains(searchdata["EmailSearch"])).ToList();
            return View(EmployeesList);
        }

        public ActionResult Create()
        {
            EmployeesList = ReadXMLData(xmlFilePath);
            EmployeesModel emp = new EmployeesModel();
            emp.EmployeeID = EmployeesList.Max(x => x.EmployeeID) + 1;
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(EmployeesModel emp)
        {
            if (ModelState.IsValid)
            {
                EmployeesList = ReadXMLData(xmlFilePath);
                EmployeesList.Add(emp);
                CreateXmlFile(xmlFilePath, EmployeesList);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int EmpId)
        {
            EmployeesList = ReadXMLData(xmlFilePath);
            int index = EmployeesList.FindIndex(x => x.EmployeeID == EmpId);
            EmployeesModel emp = EmployeesList[index];
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmployeesModel emp)
        {
            if (ModelState.IsValid)
            {
                EmployeesList = ReadXMLData(xmlFilePath);
                int index = EmployeesList.FindIndex(x => x.EmployeeID == emp.EmployeeID);
                EmployeesList[index] = emp;
                CreateXmlFile(xmlFilePath, EmployeesList);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Details (int EmpId)
        {
            EmployeesList = ReadXMLData(xmlFilePath);
            int index = EmployeesList.FindIndex(x => x.EmployeeID == EmpId);
            EmployeesModel emp = EmployeesList[index];
            return View(emp);
        }

        public ActionResult Delete (int EmpId)
        {
            EmployeesList = ReadXMLData(xmlFilePath);
            int index = EmployeesList.FindIndex(x => x.EmployeeID == EmpId);
            EmployeesModel emp = EmployeesList[index];
            return View(emp);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DelectConfirmed (int EmpId)
        {
            if (ModelState.IsValid)
            {
                EmployeesList = ReadXMLData(xmlFilePath);
                int index = EmployeesList.FindIndex(x => x.EmployeeID == EmpId);
                EmployeesList.RemoveAt(index);
                CreateXmlFile(xmlFilePath, EmployeesList);
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult BOD()
        {
            var type = EmpType.BOD.ToString();
            EmployeesList = ReadXMLData(xmlFilePath);
            EmployeesList = EmployeesList.Where(x => x.Type == type).ToList();
           
            return View(EmployeesList);
        }
        


        public ActionResult Leader()
        {
            var type = EmpType.Leader.ToString();
            EmployeesList = ReadXMLData(xmlFilePath);
            EmployeesList = EmployeesList.Where(x => x.Type == type).ToList();

            return View(EmployeesList);
        }

        public ActionResult HR()
        {
            var type = EmpType.HR.ToString();
            EmployeesList = ReadXMLData(xmlFilePath);
            EmployeesList = EmployeesList.Where(x => x.Type == type).ToList();

            return View(EmployeesList);
        }
        public ActionResult Staff()
        {
            var type = EmpType.Staff.ToString();
            EmployeesList = ReadXMLData(xmlFilePath);
            EmployeesList = EmployeesList.Where(x => x.Type == type).ToList();

            return View(EmployeesList);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Name: Bao Hoang";

            return View();
        }

        public ActionResult Combine()
        {
            EmployeesList = ReadXMLData(xmlFilePath);

            EmployeesModel emp = new EmployeesModel();
            emp.EmployeeID = EmployeesList.Max(x => x.EmployeeID) + 1;
            ViewData["Employees"] = EmployeesList;
            return View(emp);
        }

        [HttpPost]
        public ActionResult Combine(EmployeesModel emp)
        {
            if (ModelState.IsValid)
            {
                EmployeesList = ReadXMLData(xmlFilePath);
                EmployeesList.Add(emp);
                CreateXmlFile(xmlFilePath, EmployeesList);
                return RedirectToAction("Combine");
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}