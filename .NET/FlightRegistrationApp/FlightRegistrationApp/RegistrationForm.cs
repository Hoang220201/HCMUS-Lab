using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightRegistrationApp
{
    public partial class RegistrationForm : Form
    {
        string startupPath;
        string AvatarPath;
        LoginForm ParentForm;

        public RegistrationForm()
        {
            InitializeComponent();
            startupPath = LoginForm.OriginalForm.startupPath;
            ParentForm = LoginForm.OriginalForm;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDlg.Title = "Find Avatar Images";
            openFileDlg.Filter = "JPG files|*.jpg";
            openFileDlg.InitialDirectory = startupPath;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                AvatarPath = openFileDlg.FileName;
                picAvatar.Image = Image.FromFile(AvatarPath);
                picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ParentForm.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(RegistrationForm));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User obj = new User();
            Customer objcustomer = new Customer();

            if (txtCustomerID.Text.Trim().Length == 0)
            {
                MessageBox.Show("CustomerID are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            if (txtCustomerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("CustomerName are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("UserName are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            if (txtPPN.Text.Trim().Length == 0)
            {
                MessageBox.Show("PassPortNbr are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            if (txtNationality.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nationality are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Email are blank!", "Input Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }

            if (txtPassword.Text != txtComfimedPassword.Text)
            {
                MessageBox.Show("Password aren't matched", "Input Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            User SpecificOne = ParentForm.UserList.Find(x => (x.UserName == txtUserName.Text) && (x.Password == txtPassword.Text));
            if (SpecificOne != null)
            {
                MessageBox.Show("UserName is existed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            obj.UserName = txtUserName.Text;
            obj.Password = txtPassword.Text;
            obj.CustomerID = txtCustomerID.Text;

            objcustomer.CustomerID = txtCustomerID.Text;
            objcustomer.CustomerName = txtCustomerName.Text;
            objcustomer.Email = txtEmail.Text;
            objcustomer.Avatar = picAvatar.Image;
            objcustomer.Birthday = dtBirthday.Value;
            objcustomer.Gender = (rdMale.Checked == true) ? Sex.Male : Sex.Female;
            objcustomer.PassPortNbr = txtPPN.Text;
            objcustomer.Nationality = txtNationality.Text;

            ParentForm.UserList.Add(obj);
            ParentForm.CustomerList.Add(objcustomer);

            MessageBox.Show("New UserName is Cereated", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtComfimedPassword.Text = "";
            dtBirthday.Value = DateTime.Now;
            txtPPN.Text = "";
            txtNationality.Text = "";
            rdMale.Checked = true;
            rdFemale.Checked = false;
            txtEmail.Text = "";

            ComponentResourceManager resources = new ComponentResourceManager(typeof(RegistrationForm));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
   

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
