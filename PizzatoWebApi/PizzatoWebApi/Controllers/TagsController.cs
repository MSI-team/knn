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
    public class TagsController : ControllerBase
    {
        private IRestaurantRepository _restaurantRepository;

        public TagsController(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_restaurantRepository.GetUsedTags());
        }

        [HttpGet("{tag}")]
        public ActionResult<IEnumerable<Restaurant>> Get(string tag)
        {
            return Ok(_restaurantRepository.GetRestaurantsByTag(tag));
        }
    }
}