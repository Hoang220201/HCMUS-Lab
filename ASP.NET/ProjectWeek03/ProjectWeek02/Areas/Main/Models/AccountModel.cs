using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectWeek02.Areas.Main.Models
{
    public class AccountModel
    {
        private CompanyDBDataContext context = null;

        public AccountModel()
        {
            context = new CompanyDBDataContext();
        }
        public bool Login(string Email, string Password)
        {
            bool? res = false;
            context.sp_Account_Login_Check2(Email, Password, ref res);

            return (res ?? false);
        }
    }
}