using System.Collections.Generic;
using System.Linq;
using SampleASPCore.Models;

namespace SampleASPCore.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant> {
                new Restaurant{Id=1,Name="Sate Klathak Pak Jeje"},
                new Restaurant{Id=2,Name="Bakmi Jawa Mbah Hadi"},
                new Restaurant{Id=3,Name="Soto Ayam Kadipiro"}
            };
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //var results = _restaurants.OrderBy(r=>r.Name);
            var results = from r in _restaurants
                          orderby r.Name 
                          select r;
            return results;
        }

        public Restaurant GetById(int id)
        {
            var result = (from r in _restaurants
                         where r.Id==id
                         select r).SingleOrDefault();
            return result;
        }

        public void Insert(Restaurant resto)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Restaurant resto)
        {
            throw new System.NotImplementedException();
        }
    }
}