﻿using System;
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
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile csvFile)
        {
            if (csvFile is null)
                return BadRequest();

            using (var stream = csvFile.OpenReadStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var data = await reader.ReadToEndAsync();
                var restaurants = CsvDeserializer.Deserialize(data);

                _restaurantRepository.AddRestaurantsRange(restaurants);
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_restaurantRepository.Restaurants);
        }
    }
}