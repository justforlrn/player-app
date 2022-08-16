using Microsoft.AspNetCore.Mvc;
using Player.GroupOrders;
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
        [HttpGet("grab-crawler")]
        public async Task<RestaurantDto> GrabCrawlerAsync(string url, string groupid)
        {
            return await _restaurantService.GrabCrawlerAsync(url, groupid);
        }
        [HttpGet("get-list-by-name")]
        public async Task<List<RestaurantDto>> GetRestaurantsByNameAsync(string content)
        {
            return await _restaurantService.GetRestaurantsByNameAsync(content);
        }
    }
}
