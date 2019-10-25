using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi.Models
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public IList<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

        public void AddRestaurant(Restaurant restaurant)
        {
            restaurant.Id = !Restaurants.Any() ? 1 : Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(restaurant);
        }

        public void AddRestaurantsRange(IEnumerable<Restaurant> restaurants)
        {
            foreach(var restaurant in restaurants)
            {
                AddRestaurant(restaurant);
            }
        }

        public void ClearRepository()
        {
            Restaurants.Clear();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return Restaurants.AsEnumerable();
        }
    }
}
