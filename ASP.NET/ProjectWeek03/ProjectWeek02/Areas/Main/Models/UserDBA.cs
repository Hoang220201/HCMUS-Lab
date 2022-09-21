using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProjectWeek02.Areas.Main.Models
{
    public class UserDBA
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-37M40PJ\\SQLEXPRESS;Initial Catalog=ProjectMVC;Integrated Security=True");

        public string SignUp(SignUp s)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Account_SignUp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", s.FirstName +" "+ s.LastName);
                cmd.Parameters.AddWithValue("@Password", s.Password);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
                cmd.Parameters.AddWithValue("@LastName", s.LastName);
                cmd.Parameters.AddWithValue("@AccountType", "user");
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
