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
        Task<GrabRestaurantData> GrabCrawler(string url);
        Task<RestaurantDto> CreateAsync(RestaurantDto input);
    }
}
