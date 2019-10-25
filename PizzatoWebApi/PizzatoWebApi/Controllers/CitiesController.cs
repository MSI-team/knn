using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzatoWebApi.Models;

namespace PizzatoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IRestaurantRepository _restaurantRepository;

        public CitiesController(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_restaurantRepository.GetCities());
        }

        [HttpGet("{city}")]
        public ActionResult<IEnumerable<Restaurant>> Get(string city)
        {
            return Ok(_restaurantRepository.GetRestaurantsFromCity(city));
        }
    }
}