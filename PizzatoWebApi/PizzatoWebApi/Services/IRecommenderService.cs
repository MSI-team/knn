using System.Collections.Generic;
using PizzatoWebApi.Models;

namespace PizzatoWebApi
{
    public interface IRecommenderService
    {
        IEnumerable<Restaurant> Recommend(int restaurantId, string city, int recommendationsCount);
    }
}