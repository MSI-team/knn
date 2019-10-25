using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi.Models
{
    public interface IRestaurantRepository
    {
        void AddRestaurant(Restaurant restaurant);

        void AddRestaurantsRange(IEnumerable<Restaurant> restaurants);

        IEnumerable<Restaurant> GetRestaurants();

        void ClearRepository();
    }
}
