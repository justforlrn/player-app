using Player.GroupOrders;
using Player.Restaurants.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Restaurants
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> GrabCrawlerAsync(string url, string groupId);
        Task<RestaurantDto> CreateAsync(RestaurantDto input);
        Task<List<RestaurantDto>> GetRestaurantsByNameAsync(string content);
    }
}
