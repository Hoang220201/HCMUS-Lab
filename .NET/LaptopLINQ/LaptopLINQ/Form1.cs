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

namespace LaptopLINQ
{
    public partial class Form1 : Form
    {
        static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        LaptopDBDataContext db = new LaptopDBDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picLaptop.Image = Image.FromFile(ProjectPath + "\\Data\\laptop.jpg");
            picLaptop.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void DisplayData()
        {
            dgwLaptop.DataSource = (from sp in db.Laptops select sp);
            dgwLaptop.Columns["ImageName"].Visible = false;
            dgwLaptop.Columns["colLaptopID"].ReadOnly = true;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dgwLaptop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwLaptop.Focused == false || dgwLaptop.CurrentCell == null)
                return;
            int RowIndex = dgwLaptop.CurrentRow.Index;
            string SelectedLaptopID = dgwLaptop.Rows[RowIndex].Cells[0].Value.ToString();

            string LaptopImage = (from sp in db.Laptops
                                  where sp.LaptopID == SelectedLaptopID
                                  select sp.ImageName).FirstOrDefault();
            if (LaptopImage == null)
                return;
            picLaptop.Image = Image.FromFile(ProjectPath + "\\Data\\" + LaptopImage);
            picLaptop.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int RowIndex = dgwLaptop.CurrentRow.Index;
            string SelectedLaptopID = dgwLaptop.Rows[RowIndex].Cells[0].Value.ToString();

            Laptop deletedSP = (from sp in db.Laptops
                                where sp.LaptopID == SelectedLaptopID
                                select sp).SingleOrDefault();
            db.Laptops.DeleteOnSubmit(deletedSP);
            db.SubmitChanges();
            DisplayData();

            MessageBox.Show("Laptop :" + deletedSP.LaptopID + "is deleted!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int RowIndex = dgwLaptop.CurrentRow.Index;
            string SelectedLaptopID = dgwLaptop.Rows[RowIndex].Cells[0].Value.ToString();

            Laptop updateSP = (from sp in db.Laptops
                               where sp.LaptopID == SelectedLaptopID
                               select sp).SingleOrDefault();

            updateSP.LaptopID = dgwLaptop.Rows[RowIndex].Cells[0].Value.ToString();
            updateSP.LaptopName = dgwLaptop.Rows[RowIndex].Cells[1].Value.ToString();
            updateSP.LaptopType = dgwLaptop.Rows[RowIndex].Cells[2].Value.ToString();
            updateSP.ProductDate = DateTime.Parse(dgwLaptop.Rows[RowIndex].Cells[3].Value.ToString());
            updateSP.Processor = dgwLaptop.Rows[RowIndex].Cells[4].Value.ToString();
            updateSP.HDD = dgwLaptop.Rows[RowIndex].Cells[5].Value.ToString();
            updateSP.RAM = dgwLaptop.Rows[RowIndex].Cells[6].Value.ToString();
            updateSP.Price = Convert.ToInt32(dgwLaptop.Rows[RowIndex].Cells[7].Value.ToString());
            updateSP.ImageName = "laptop.jpg";

            db.SubmitChanges();
            DisplayData();
            MessageBox.Show("Laptop :" + updateSP.LaptopID + " is updated");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Laptop checkedSP;
            List<Laptop> SPList = (from sp in db.Laptops
                                   where sp.LaptopID.Contains("NEW")
                                   select sp).ToList();
            string NewID = "NEW";
            if (SPList.Count == 0)
                NewID = NewID + "001";
            else
            {
                checkedSP = SPList.Last();
                NewID = NewID + NextId(checkedSP.LaptopID.Substring(checkedSP.LaptopID.Length - 3));

            }

            Laptop insertedSP = new Laptop();
            insertedSP.LaptopID = NewID;
            insertedSP.LaptopName = "Not Assigned";
            insertedSP.LaptopType = "Not Assigned";
            insertedSP.ProductDate = DateTime.Now;
            insertedSP.Processor = "Not Assigned";
            insertedSP.HDD = "Not Assigned";
            insertedSP.RAM = "Not Assigned";
            insertedSP.Price = 0;
            insertedSP.ImageName = "laptop.jpg";

            db.Laptops.InsertOnSubmit(insertedSP);
            db.SubmitChanges();
            DisplayData();
            MessageBox.Show("New laptop is inserted! Please update data and press button Update");
        }
        public string NextId(string currentId)
        {
            int i = 0;
            if (int.TryParse(currentId, out i))
            {
                i++;
                return (i.ToString().PadLeft(3, '0'));
            }
            throw new System.ArgumentException("Non-numeric string passed as argument");
        }
    }
}
