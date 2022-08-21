using Player.Items;
using Player.Options;
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
        Task<Restaurant> GetByIdAsync(string id);
        //Task<bool> IsItemIdsExistAsync(List<string> itemIds);
        //Task<List<Item>> GetItemsByIdsAsync(List<string> ids);
        //Task<bool> IsOptionsIdsExistAsync(List<string> itemIds);
        //Task<List<Option>> GetOptionsByIdsAsync(List<string> ids);
    }
}
