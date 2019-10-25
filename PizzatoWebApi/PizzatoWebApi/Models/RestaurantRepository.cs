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

        public IEnumerable<Restaurant> GetRestaurantsFromCity(string city)
        {
            return Restaurants.Where(r => r.City == city).ToList();
        }

        public IEnumerable<string> GetUsedTags()
        {
            return Restaurants.SelectMany(r => r.Tags).Distinct().OrderBy(r => r);
        }

        public IEnumerable<Restaurant> GetRestaurantsByTag(string tag)
        {
            return Restaurants.Where(r => r.Tags.Contains(tag));
        }

        public void RecalculateFeatureVectors()
        {
            var tags = GetUsedTags().ToList();

            foreach(var restaurant in Restaurants)
            {
                restaurant.FeatureVector = FeatureVectorCalculator.CalculateFeatureVector(restaurant.Tags, tags);
            }
        }
    }
}
