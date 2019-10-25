using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi.Models
{
    public interface IRestaurantRepository
    {
        IList<Restaurant> Restaurants { get; set; }

        void AddRestaurant(Restaurant restaurant);

        void AddRestaurantsRange(IEnumerable<Restaurant> restaurants);
        IEnumerable<Restaurant> GetRestaurantsFromCity(string city);
    }
}
