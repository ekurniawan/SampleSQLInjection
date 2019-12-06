using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SampleASPCore.Models;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.Services
{
    public class LoginServices : ILogin
    {
        private IConfiguration _config;
        public LoginServices(IConfiguration config)
        {
            _config = config;
        }

        public Login ProcessLogin(Login obj)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                Login loginResult = new Login();
                //string strSql = "select * from Login where Email='" + obj.Email + "' and Password='" + obj.Password + "' ";
                string strSql = "select * from Login where Email=@Email and Password=@Password";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Password", obj.Password);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    loginResult.Name = dr["Name"].ToString();
                    loginResult.Email = dr["Email"].ToString();
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return loginResult;
            }
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

       

    }
}
