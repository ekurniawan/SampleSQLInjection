using System.Collections.Generic;
using SampleASPCore.Models;

namespace SampleASPCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        void Insert(Restaurant resto);
        void Update(Restaurant resto);
        void Delete(int id);
    }
}