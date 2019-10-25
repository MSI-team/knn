using PizzatoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi
{
    public class RecommenderService : IRecommenderService
    {
        private IRestaurantRepository _restaurantRepository;

        public RecommenderService(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }

        public IEnumerable<Restaurant> Recommend(int restaurantId, string city, int recommendationsCount)
        {
            return KNearestNeighboursSearch(restaurantId, _restaurantRepository.GetRestaurantsFromCity(city), recommendationsCount);
        }

        private IEnumerable<Restaurant> KNearestNeighboursSearch(int restaurantId, IEnumerable<Restaurant> restaurants, int k)
        {
            var restaurantNeighbours = new List<(int distance, Restaurant restaurant)>();
            var restaurant = restaurants.FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant is null)
            {
                return new List<Restaurant>();
            }

            foreach (Restaurant r in restaurants)
            {
                if (r.Id == restaurant.Id)
                    continue;

                long differenceBitMask = r.FeatureVector ^ restaurant.FeatureVector;
                int squareDistance = (int)CountSetBits(differenceBitMask);
                restaurantNeighbours.Add((squareDistance, r));
            }

            return restaurantNeighbours.OrderBy(n => n.distance).Select(n => n.restaurant).Take(k);
        }

        private long CountSetBits(long n)
        {
            long count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
    }
}
