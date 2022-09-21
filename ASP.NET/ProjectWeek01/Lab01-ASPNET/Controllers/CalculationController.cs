using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;


namespace Lab01_ASPNET.Controllers
{
    public class CalculationController : Controller
    {
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        // GET: Calculation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Addition()
        {
            string strNumber1 = Request.QueryString["Number1"];
            string strNumber2 = Request.QueryString["Number2"];
            if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
            {
                int add = Convert.ToInt32(strNumber1) + Convert.ToInt32(strNumber2);
                return View((object)add.ToString());
            }
            else
            {
                return View((object)("Invalid ! Your Input must be a number"));
            }
        }

        public ActionResult Subtraction()
        {
            string strNumber1 = Request.QueryString["Number1"];
            string strNumber2 = Request.QueryString["Number2"];
            if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
            {
                int Sub = Convert.ToInt32(strNumber1) - Convert.ToInt32(strNumber2);
                return View((object)Sub.ToString());
            }
            else
            {
                return View((object)("Invalid ! Your Input must be a number"));
            }
        }

        public ActionResult Muitiplication()
        {
            string strNumber1 = Request.QueryString["Number1"];
            string strNumber2 = Request.QueryString["Number2"];
            if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
            {
                int Muitip = Convert.ToInt32(strNumber1) * Convert.ToInt32(strNumber2);
                return View((object)Muitip.ToString());
            }
            else
            {
                return View((object)("Invalid ! Your Input must be a number"));
            }
        }

        public ActionResult Division()
        {
            string strNumber1 = Request.QueryString["Number1"];
            string strNumber2 = Request.QueryString["Number2"];
            if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
            {
                int Divi = Convert.ToInt32(strNumber1) / Convert.ToInt32(strNumber2);
                return View((object)Divi.ToString());
            }
            else
            {
                return View((object)("Invalid ! Your Input must be a number"));
            }
        }

        public ActionResult ArryStats(string Arr)
        {
            string Array = Arr;
            string Check = Request.QueryString["Check"];

            int num = 0;
            int Max = 0;
            int Min = 10000;
            for (int i = 1; i < Arr.Length; i=i+2)
            {
                num++;

                if (((int)(Arr[i] - '0')) > Max)
                    Max = (int)(Arr[i] - '0');

                if (((int)(Arr[i] - '0')) < Min)
                    Min = (int)(Arr[i] - '0');
            }

            if (String.Compare(Check, "Min", true) == 0)
            {
                return View((object)("Min is " + Min.ToString()));
            }
            else if (String.Compare(Check, "Max", true) == 0)
            {
                return View((object)("Max is " + Max.ToString()));
            }
            else if (String.Compare(Check, "Num", true) == 0)
            {
                return View((object)("has " + num.ToString() + " elements"));
            }
            return View((object)("has " + num.ToString() + " elements and max is "
                                     + Max.ToString() + " and min is " + Min.ToString()));
        }

        public ActionResult All (string Number1, string Number2, string Do)
        {
            string strNumber1 = Number1;
            string strNumber2 = Number2;
            string strDo = Do;

            if (String.Compare(Do, "Addition", true) == 0)
            {
                if (IsNumber(Number1) == true && IsNumber(Number2) == true)
                {
                    int add = Convert.ToInt32(Number1) + Convert.ToInt32(Number2);
                    return View((object)add.ToString());
                }
                else
                {
                    return View((object)("Invalid ! Your Input must be a number"));
                }
            }
            else if (String.Compare(strDo, "Division", true) == 0)
            {
                if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
                {
                    int Divi = Convert.ToInt32(strNumber1) / Convert.ToInt32(strNumber2);
                    return View((object)Divi.ToString());
                }
                else
                {
                    return View((object)("Invalid ! Your Input must be a number"));
                }
            }
            else if (String.Compare(strDo, "Subtraction", true) == 0)
            {
                if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
                {
                    int Sub = Convert.ToInt32(strNumber1) - Convert.ToInt32(strNumber2);
                    return View((object)Sub.ToString());
                }
                else
                {
                    return View((object)("Invalid ! Your Input must be a number"));
                }
            }
            else if (String.Compare(strDo, "Multiplication", true) == 0)
            {
                if (IsNumber(strNumber1) == true && IsNumber(strNumber2) == true)
                {
                    int Muitip = Convert.ToInt32(strNumber1) * Convert.ToInt32(strNumber2);
                    return View((object)Muitip.ToString());
                }
                else
                {
                    return View((object)("Invalid ! Your Input must be a number"));
                }
            }
            return View((object)("Invalid ! Your Input must have Do value"));
        }

    }
}