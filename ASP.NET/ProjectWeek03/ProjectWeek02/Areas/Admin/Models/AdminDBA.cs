using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ProjectWeek02.Areas.Admin.Models;
using System.Data;

namespace ProjectWeek02.Areas.Admin.Models
{
    public class AdminDBA
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-37M40PJ\\SQLEXPRESS;Initial Catalog=ProjectMVC;Integrated Security=True");

        public string SignUp(SignUp s)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Account_SignUp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", s.UserName);
                cmd.Parameters.AddWithValue("@Password", s.Password);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                cmd.Parameters.AddWithValue("@FirstName", s.UserName);
                cmd.Parameters.AddWithValue("@LastName", s.UserName);
                cmd.Parameters.AddWithValue("@AccountType", "admin");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("OK");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}