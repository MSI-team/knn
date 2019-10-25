using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi.Models.FakeModels
{
    public class FakeRestaurantRepository : RestaurantRepository
    {
        public FakeRestaurantRepository()
        {
            AddRestaurantsRange(new List<Restaurant>()
            {
                new Restaurant()
                {
                    City = "Warsaw"
                },
                new Restaurant()
                {
                    City = "Abbdsd"
                },
                new Restaurant()
                {
                    City = "Bialystok"
                }
            });
        }
    }
}
