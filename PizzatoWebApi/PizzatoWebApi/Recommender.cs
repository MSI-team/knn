﻿using PizzatoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi
{
    public class Recommender
    {
        private RestaurantRepository restaurantRepository;

        public Recommender(RestaurantRepository repository)
        {
            restaurantRepository = repository;
        }
        public List<Restaurant> Recommend(Restaurant restaurant, string city, int recommendationsCount)
        {
            return KNearestNeighboursSearch(restaurant, restaurantRepository.GetRestaurantsFromCity(city), recommendationsCount);
        }
        private List<Restaurant> KNearestNeighboursSearch(Restaurant restaurant, List<Restaurant> restaurants, int k)
        {
            List<(int, Restaurant)> restaurantNeighbours = new List<(int, Restaurant)>();
            foreach (Restaurant r in restaurants)
            {
                if (r == restaurant)
                    continue;
                long differenceBitMask = r.FeatureVector ^ restaurant.FeatureVector;
                int squareDistance = (int)CountSetBits(differenceBitMask);
                restaurantNeighbours.Add((squareDistance, r));
            }
            restaurantNeighbours.Sort(delegate ((int, Restaurant) x, (int, Restaurant) y)
            {
                return x.Item1.CompareTo(y.Item1);
            });

            return restaurantNeighbours.GetRange(0, k).Select(r => r.Item2).ToList();
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