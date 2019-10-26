using System.Collections.Generic;
using PizzatoWebApi.Models;

namespace PizzatoWebApi.Services
{
    public interface ICsvDeserializer
    {
        IList<Restaurant> Deserialize(string csvContent);
    }
}