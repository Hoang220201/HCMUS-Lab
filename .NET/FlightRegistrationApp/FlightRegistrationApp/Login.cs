using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FlightRegistrationApp
{
    public partial class LoginForm : Form
    {
        public static LoginForm OriginalForm;
        public List<Customer> CustomerList;
        public List<User> UserList;
        public List<Flight> FlightList;
        public List<FlightRegistration> FlightRegList;
        public string startupPath;
        public bool ResetLogin;

        public LoginForm()
        {
            InitializeComponent();
            OriginalForm = this;
            startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            CustomerList = new List<Customer>();
            CustomerList.Add(new Customer("ST000", "Admin", "A0746213", "VN",
                              Sex.Male, DateTime.Now, "admin@gmail.com",
                              Image.FromFile(startupPath + "\\admin.jpg")));

            UserList = new List<User>();
            UserList.Add(new User("Admin", "220201", "ST000"));

            FlightList = new List<Flight>();
            FlightList.Add(new Flight("F001", "Vietnam Airline", "8:30am", "14:00pm"));
            FlightList.Add(new Flight("F002", "Vietjet Air", "11:40am", "16:10pm"));
            FlightList.Add(new Flight("F003", "Jetstar Pacific Airlines", "1:00am", "5:30am"));
            FlightList.Add(new Flight("F004", "Bamboo Airways", "6:50am", "11:20am"));

            FlightRegList = new List<FlightRegistration>();
            ResetLogin = true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Please enter user name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
                return;
            }

            User SpecificOne = UserList.Find(x => (x.UserName == txtUserName.Text) && (x.Password == txtPassword.Text));
            if (SpecificOne == null)
            {
                MessageBox.Show("Username and Password are incorrect. \n Please reinput or register a new one",
                                "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
            }

            FlightSelectionForm obj = new FlightSelectionForm();
            User currentUser = UserList.Find(x => (x.UserName == txtUserName.Text) && (x.Password == txtPassword.Text));
            obj.SetCurrentUser(currentUser);
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void linkLblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm obj = new RegistrationForm();
            this.Hide();
            obj.Show();
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            if(ResetLogin == true)
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
