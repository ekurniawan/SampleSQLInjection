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
            throw new System.NotImplementedException();
        }
    }
}