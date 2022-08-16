using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.Restaurants
{
    public interface IRestaurantRepository : IRepository<Restaurant, string>
    {
        Task<List<Restaurant>> GetRestaurantsByNameAndIdAsync(string content);
    }
}
