using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlightRegistrationApp
{
    public enum Sex { Male, Female };
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PassPortNbr { get; set; }
        public string Nationality { get; set; }
        public Sex Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public Image Avatar { get; set; }

        public Customer()
        {
            CustomerID = "Not Assigned";
        }
        public Customer(string CustomerID, string CustomerName, string PassPortNbr, string Nationality, Sex Gender, DateTime Birthday, string Email, Image Avatar)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.PassPortNbr = PassPortNbr;
            this.Nationality = Nationality;
            this.Gender = Gender;
            this.Birthday = Birthday;
            this.Email = Email;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CustomerID { get; set; }

        public User()
        {
            UserName = "Not Assigned";
        }

        public User(string UserName, string Password, string CustomerID)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.CustomerID = CustomerID;
        }
    }

    public class Flight
    {
        public string FlightID { get; set; }
        public string FlightType { get; set; }
        public string TimeDepart { get; set; }
        public string TimeArrival { get; set; }
        

        public Flight()
        {
            FlightID = "Not Assigned";
        }

        public Flight(string FlightID, string FlightType, string TimeDepart, string TimeArrival)
        {
            this.FlightID = FlightID;
            this.FlightType = FlightType;
            this.TimeDepart = TimeDepart;
            this.TimeArrival = TimeArrival;
            
        }
    }

    public class FlightRegistration
    {
        public string CustomerID { get; set; }
        public List<Flight> FlightEnrolList;

        public FlightRegistration()
        {
            CustomerID = "Not Assigned";
            FlightEnrolList = new List<Flight>();
        }
        public FlightRegistration(string CustomerID)
        {
            this.CustomerID = CustomerID;
            FlightEnrolList = new List<Flight>();
        }
       
    }
}
