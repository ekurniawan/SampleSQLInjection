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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Insert(Restaurant resto)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant resto)
        {
            throw new NotImplementedException();
        }
    }
}
