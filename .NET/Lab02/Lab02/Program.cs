using System;
using System.Globalization;
using MainData;
using Attribute;
using System.IO;

delegate void MilkInputDisplay(string Milkname = "", string ProductionDate = "02/11/2021",
                    string ExpiredDate = "02/05/2021", int Quantity = 0);

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Milk milks = new Milk();
            milks.ValMilkname = "true MILK";
            milks.ValProductionDate = "04/11/2021";
            milks.ValExpiredDate = "04/05/2022";
            milks.ValQuantity = 10;

            Console.WriteLine("Thong tin milk:");
            Console.WriteLine("\t MilkID = {0}, Milkname = {1}", milks.ValMilkID, milks.ValMilkname);
            Console.WriteLine("\t ProductionDate = {0}, ExpiredDate = {1}", milks.ValProductionDate, milks.ValExpiredDate);
            Console.WriteLine("\t Quantity = {0} hop", milks.ValQuantity);

            Type type = typeof(Milk);
            string OutputMessage = "Thong tin them cua MILK:";
            Console.WriteLine(OutputMessage);
            foreach (Object attributes in type.GetCustomAttributes(false))
            {
                MilkMoreInfo cinfo = (MilkMoreInfo)attributes;
                if (cinfo != null)
                {
                    OutputMessage = String.Format("\t Manufacturer = {0}", cinfo.Manufacturer);
                    OutputMessage += String.Format("\n\t CompanyName = {0}", cinfo.CompanyName);
                    Console.WriteLine(OutputMessage);
                }
            }

            MilkInputDisplay action1 = new MilkInputDisplay(milks.InputMilk);
            MilkInputDisplay action2 = new MilkInputDisplay(milks.DisplayMilk);

            action1.Invoke();
            action2.Invoke();
            

            Console.ReadKey();
        }
    }
}

namespace MainData
{
    public interface IMilkAction
    {
        void DisplayMilk(string Milkname = "", string ProductionDate = "02/11/2021",
                    string ExpiredDate = "02/05/2021", int Quantity = 0);
        void InputMilk(string Milkname = "", string ProductionDate = "02/11/2021",
                    string ExpiredDate = "02/05/2021", int Quantity = 0);
    }

    [MilkMoreInfo("TH true MILk", "TH Group")]
    class Milk : IMilkAction
    {
        private string Milkname;
        private string MilkID;
        private DateTime ProductionDate;
        private DateTime ExpiredDate;
        private int Quantity;
        
        public Milk(string Milkname = "", string ProductionDate = "02/11/2021", 
                    string ExpiredDate = "02/05/2021", int Quantity = 0)
        {
            this.Milkname = Milkname;
            this.MilkID = string.Format("MILK{0}",this.ProductionDate.ToString("ddMMyyyy"));
            this.ProductionDate = DateTime.ParseExact(ProductionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.ExpiredDate = DateTime.ParseExact(ExpiredDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.Quantity = Quantity;
        }

        public string ValMilkname
        {
            get { return Milkname; }
            set { Milkname = value; }
        }

        public string ValMilkID
        {
            get { return MilkID; }
        }

        public string ValProductionDate
        {
            get { return ProductionDate.ToString("dd/MM/yyyy"); }
            set { ProductionDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                MilkID = String.Format("MILK{0}", this.ProductionDate.ToString("ddMMyyyy"));
            }
        }

        public string ValExpiredDate
        {
            get { return ExpiredDate.ToString("dd/MM/yyyy"); }
            set
            {
                ExpiredDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        public int ValQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }

        }

        public void InputMilk(string Milkname = "", string ProductionDate = "02/11/2021",
                    string ExpiredDate = "02/05/2021", int Quantity = 0)
        {
            Console.WriteLine("Input Milkname:");
            ValMilkname = Console.ReadLine();
            Console.WriteLine("Input ProductionDate:");
            ValProductionDate = Console.ReadLine();
            Console.WriteLine("Input ExpiredDate:");
            ValExpiredDate = Console.ReadLine();
            Console.WriteLine("Input Quantity:");
            string q = Console.ReadLine();
            ValQuantity = int.Parse(q);
        }

        public void DisplayMilk(string Milkname = "", string ProductionDate = "02/11/2021",
                    string ExpiredDate = "02/05/2021", int Quantity = 0)
        {
            Console.WriteLine("Thong tin Milk vua nhap:");
            Console.WriteLine("\t MilkID = {0}, Milkname = {1}", ValMilkID, ValMilkname);
            Console.WriteLine("\t ProductionDate = {0}, ExpiredDate = {1}", ValProductionDate, ValExpiredDate);
            Console.WriteLine("\t Quantity = {0} hop", ValQuantity);

        }

    }
}

namespace Attribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MilkMoreInfo : System.Attribute
    {
        public string Manufacturer { get; set; }
        public string CompanyName { get; set; }

        public MilkMoreInfo(string Manufacturer = "", string CompanyName = "")
        {
            this.Manufacturer = Manufacturer;
            this.CompanyName = CompanyName;
        }
    }
}