using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzatoWebApi.Models
{
    public class Restaurant
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public List<string> Tags { get; set; }

        [JsonIgnore]
        public long FeatureVector { get; set; }
    }
}
