using System.Collections.Generic;
using SampleASPCore.Models;

using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace SampleASPCore.Services
{
    public class RestaurantService : IRestaurantData
    {
        private IConfiguration _config;
        public RestaurantService(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr(){
            return _config.GetConnectionString("DefaultConnection");
        }
        
        public IEnumerable<Restaurant> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                string strSql = @"select * from Restaurants order by Name asc";

                SqlCommand cmd = new SqlCommand(strSql,conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows){
                    while(dr.Read()){
                        lstRestaurant.Add(
                            new Restaurant{
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"].ToString()
                            }
                        );
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return lstRestaurant;
            }
        }

        public Restaurant GetById(int id)
        {
            Restaurant resto = new Restaurant();
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurants where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql,conn);
                cmd.Parameters.AddWithValue("@Id",id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows){
                    dr.Read();
                    resto.Id = Convert.ToInt32(dr["Id"]);
                    resto.Name = dr["Name"].ToString();
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();

                return resto;
            }
        }

        public void Insert(Restaurant resto)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Restaurant(Name) values(@Name)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name",resto.Name);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        public void Update(Restaurant resto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}