using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SampleASPCore.Models;
using Dapper;
using System.Data.SqlClient;

namespace SampleASPCore.Services
{
    public class RestaurantServiceDapper : IRestaurantData
    {
        private IConfiguration _config;
        public RestaurantServiceDapper(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Restaurants where Id=@Id";
                var param = new { Id = id };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurants order by Name asc";
                var results = conn.Query<Restaurant>(strSql);
                return results;
            }
        }

        public Restaurant GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                /*string strSql = @"select * from Restaurants where Id=@Id";
                var param = new { Id = id };
                var result = conn.QuerySingle<Restaurant>(strSql, param);
                return result;*/
                string strSp = "sp_RestaurantById";
                var param = new { Id = id };
                var result = conn.QuerySingle<Restaurant>(strSp, param,
                    commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public void Insert(Restaurant resto)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Restaurants(Name) values(@Name)";
                var param = new { Name = resto.Name };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Update(Restaurant resto)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Restaurants set Name=@Name where Id=@Id";
                var param = new { Name = resto.Name,Id=resto.Id };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
