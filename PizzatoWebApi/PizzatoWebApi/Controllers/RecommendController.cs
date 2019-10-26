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
    public class RecommendController : ControllerBase
    {
        private IRecommenderService _recommenderService;

        public RecommendController(IRecommenderService recommenderService)
        {
            _recommenderService = recommenderService;
        }

        [HttpGet("{restaurantId}/{city}/{recommendationsCount}")]
        public ActionResult<IEnumerable<Restaurant>> Get(int restaurantId, string city, int recommendationsCount)
        {
            var recommendations = _recommenderService.Recommend(restaurantId, city, recommendationsCount);

            return Ok(recommendations);
        }
    }
}