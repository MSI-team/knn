using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzatoWebApi.Models
{
    public class Restaurant
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        public string PhotoUrl { get; set; }

        public List<string> Tags { get; set; }

        [JsonIgnore]
        public long FeatureVector { get; set; }
    }
}
