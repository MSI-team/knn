﻿using PizzatoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi.Services
{
    public class CsvDeserializer : ICsvDeserializer
    {
        public IList<Restaurant> Deserialize(string csvContent)
        {
            var restaurants = new List<Restaurant>();

            foreach (var line in csvContent.Split(Environment.NewLine))
            {
                var data = line.Split(";");
                var tags = data[3].Split(",");

                restaurants.Add(new Restaurant
                {
                    Name = data[0],
                    City = data[1],
                    Address = data[2],
                    Tags = tags.ToList()
                });
            }

            return restaurants;
        }
    }
}
