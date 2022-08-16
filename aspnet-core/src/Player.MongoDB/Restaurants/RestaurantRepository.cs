using MongoDB.Driver;
using Player.Items;
using Player.MongoDB;
using Player.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Player.Restaurants
{
    public class RestaurantRepository : MongoDbRepository<PlayerMongoDbContext, Restaurant, string>, IRestaurantRepository
    {
        public RestaurantRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Item>> GetItemsByIdsAsync(List<string> ids)
        {
            var collection = await GetCollectionAsync();
            var filterIn = Builders<Item>.Filter.In(x => x.Id, ids);
            var filterElemMatch = Builders<Restaurant>.Filter.ElemMatch(x => x.Items, filterIn);
            var restaurant = await collection.FindAsync(filterElemMatch);
            return await items.ToListAsync();
        }

        public Task<List<Option>> GetOptionsByIdsAsync(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Restaurant>> GetRestaurantsByNameAndIdAsync(string content)
        {
            var collection = await GetCollectionAsync();
            var result = await collection.FindAsync(e => e.Name.Contains(content) || e.Id == content);
            return await result.ToListAsync();
        }

        public Task<bool> IsItemIdsExistAsync(List<string> itemIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsOptionsIdsExistAsync(List<string> itemIds)
        {
            throw new NotImplementedException();
        }
    }
}
