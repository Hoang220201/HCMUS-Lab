using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectWeek02.Areas.Admin.Models
{
    public class AccountModel
    {
        private CompanyDBDataContext context = null;

        public AccountModel()
        {
            context = new CompanyDBDataContext();
        }
        public bool Login(string UserName, string Password)
        {
            bool? res = false;
            context.sp_Account_Login_Check(UserName, Password, ref res);

            return (res ?? false);
        }
    }
}