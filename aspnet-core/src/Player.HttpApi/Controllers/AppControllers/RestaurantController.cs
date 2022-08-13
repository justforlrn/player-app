using Microsoft.AspNetCore.Mvc;
using Player.Restaurants;
using Player.Restaurants.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Player.Controllers.AppControllers
{
    [Route("restaurants")]
    public class RestaurantController : AbpController
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpPost("grab-crawler")]
        public async Task<GrabRestaurantData> GrabCrawler(string url)
        {
            return await _restaurantService.GrabCrawler(url);
        }
    }
}
