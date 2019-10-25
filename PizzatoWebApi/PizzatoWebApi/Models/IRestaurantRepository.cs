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

        IEnumerable<string> GetCities();

        IEnumerable<Restaurant> GetRestaurantsFromCity(string city);

        IEnumerable<Restaurant> GetRestaurantsByTag(string tag);

        IEnumerable<string> GetUsedTags();

        void RecalculateFeatureVectors();
    }
}
