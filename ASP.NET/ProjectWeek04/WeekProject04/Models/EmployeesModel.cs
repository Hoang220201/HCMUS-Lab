using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeekProject04.Models
{
    public class EmployeesModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" , ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string Type { get; set; }
        
    }

    public enum EmpType
    {
        BOD, Leader, HR, Staff
    }

}