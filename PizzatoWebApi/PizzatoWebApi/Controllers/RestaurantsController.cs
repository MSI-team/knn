using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzatoWebApi.Models;
using PizzatoWebApi.Services;

namespace PizzatoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantsController(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }
        
        // POST api/restaurants
        [HttpPost("import")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file is null)
                return BadRequest();

            using (var stream = file.OpenReadStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var data = await reader.ReadToEndAsync();
                var restaurants = CsvDeserializer.Deserialize(data);

                _restaurantRepository.ClearRepository();
                _restaurantRepository.AddRestaurantsRange(restaurants);
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            return Ok(_restaurantRepository.GetRestaurants());
        }

        // GET api/restaurant/{id}
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            var restaurant = _restaurantRepository.GetRestaurants().FirstOrDefault(r => r.Id == id);
            if(restaurant is null)
            {
                return BadRequest();
            }

            return restaurant;
        }

        [HttpPost("add")]
        public IActionResult Post([FromBody] Restaurant restaurant)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _restaurantRepository.AddRestaurant(restaurant);
            return Ok(restaurant.Id);
        }
    }
}