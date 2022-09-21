 using System;
 using System.Collections.Generic;
 using System.Linq;
 using MainData;

namespace Lab03
{
    class Program
    {
        static void UpdateNumberOfCustomers(Company company)
        {
            company.ValNumberOfCustomer = company.Customers.Count;
        }

        static void Main(string[] args)
        {
            Company company = new Company();
            company.ValName = "VNG";
            company.CompanyAddorRemoveEvent += new Company.CompanyHandler(UpdateNumberOfCustomers);

            company.AddCustomer(new Customer("C001", "Hoang", "124 Hong Bang", 0909480733, CustomerType.TrungThanh));
            company.AddCustomer(new Customer("C002", "Bao", "132 Hong Bang", 0909621234, CustomerType.TiemNang));
            company.AddCustomer(new Customer("C003", "Anh", "676 Nguyen Trai", 0909245563, CustomerType.CanQuanTam));
            company.AddCustomer(new Customer("C004", "Ky", "277 Nguyen Van Cu", 0909452563, CustomerType.KhachHangKhac));

            company.CompanyInfo();

            Customer customer = company.SearchCustomer("C002");
            company.RemoveCustomer(customer);
            company.CompanyInfo();

            Console.WriteLine("Searching Process:");
            Console.WriteLine(company.SearchCustomer("C002").ConvertToString());
            Console.WriteLine(company.SearchCustomer(1).ConvertToString());

            Console.ReadKey();

        }
    }
}

namespace MainData
{
    public enum CustomerType { TrungThanh, TiemNang, CanQuanTam, KhachHangKhac};

    public class Customer
    {
        private string CustomerID = "C000";  
        private string CustomerName;
        private string CustomerAddress;
        private int CustomerPhone;
        CustomerType customertype;

        public Customer() {}

        public Customer(string CustomerID, string CustomerName, string CustomerAddress, int CustomerPhone, CustomerType customertype)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.CustomerAddress = CustomerAddress;
            this.CustomerPhone = CustomerPhone;
            this.customertype = customertype;
        }

        public string ValCustomerID
        {
            get { return CustomerID; }
            set { CustomerID = value; }
        }
        public string ValCustomerName
        {
            get { return CustomerName; }
            set { CustomerName = value; }
        }
        public string ValCustomerAddress
        {
            get { return CustomerAddress; }
            set { CustomerAddress = value; }
        }
        public int ValCustomerPhone
        {
            get { return CustomerPhone; }
            set { CustomerPhone = value; }
        }
        public CustomerType Valcustomertype
        {
            get { return customertype; }
            set { customertype = value; }
        }

        public void CustomerInfo()
        {
            string ct = Enum.GetName(typeof(CustomerType), customertype);
            if (CustomerID != "C000")
            {
                Console.WriteLine("Ma KH: {0}", CustomerID);
                Console.WriteLine("Ten: {0}", CustomerName);
                Console.WriteLine("Dia Chi: {0}", CustomerAddress);
                Console.WriteLine("SDT: {0}", CustomerPhone);
                Console.WriteLine("Loai: {0}", ct);
            }
        }

    }

    public class Company
    {
       
        public List<Customer> Customers { get; set; }
        Dictionary<CustomerType, string> customerinfo = new Dictionary<CustomerType, string>();

        public delegate void CompanyHandler(Company company);
        public event CompanyHandler CompanyAddorRemoveEvent;

        int NumberOfCustomer;
        string Name;

        public Company()
        {
            Customers = new List<Customer>();
            Name = "Not Assigned";
            customerinfo.Add(CustomerType.TrungThanh, "Khach hang trung thanh la khach hang lau nam");
            customerinfo.Add(CustomerType.TiemNang, "Khach hang tiem nang la nguoi co nhu cau, quan tam sp cua cong ty");
            customerinfo.Add(CustomerType.CanQuanTam, "Khach hang can quan tam la khach hang can duoc chu y");
            customerinfo.Add(CustomerType.KhachHangKhac, "Khach hang loai khac la nhung loai khach hang khac voi tren");
        }

        public string ValName
        {
            get { return Name; }
            set { Name = value; }
        }
        public int ValNumberOfCustomer
        {
            get { return NumberOfCustomer; }
            set { NumberOfCustomer = value; }
        }

        public void CompanyInfo()
        {
            Console.WriteLine("So khach hang cua cong ty {0}:{1}", Name, NumberOfCustomer);
            foreach (Customer rm in Customers)
            {
                KeyValuePair<CustomerType, string> info = customerinfo.FirstOrDefault(o => o.Key == rm.Valcustomertype);
                rm.CustomerInfo();
                Console.WriteLine("---Thong Tin Khach Hang: {0}\n", info.Value);
            }
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            OnCompanyChanger(this);
        }
        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
            OnCompanyChanger(this);
        }
        public void OnCompanyChanger(Company company)
        {
            if (CompanyAddorRemoveEvent != null)
            {
                CompanyAddorRemoveEvent(this);
            }
        }

        public Customer SearchCustomer<T> (T search)
        {
            Customer c = new Customer();
            if (typeof(T) == typeof(string))
            {
                c = Customers.FirstOrDefault(o => o.ValCustomerID == search.ToString());
                if (c != null)
                    return c;
            }
            else if (typeof(T) == typeof(int))
            {
                if (Convert.ToInt32(search) < Customers.Count) 
                    return Customers[Convert.ToInt32(search)];
            }
            Console.WriteLine(" Customer is not found!");
            return new Customer();
        }
    }

    public static class MyExtensions
    {
        public static string ConvertToString(this Customer customer)
        {
            string customertype = Enum.GetName(typeof(CustomerType), customer.Valcustomertype);
            if (customer.ValCustomerID != "C000")
                return String.Format(" Ma KH: {0}\n Ten: {1}\n Dia Chi: {2}\n SDT: {3}\n Loai: {4}", customer.ValCustomerID,
                    customer.ValCustomerName, customer.ValCustomerAddress, customer.ValCustomerPhone, customertype);
            else
                return "";
        }
    }
    
}
