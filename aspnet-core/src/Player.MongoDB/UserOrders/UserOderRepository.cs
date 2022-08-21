using MongoDB.Driver;
using Player.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Player.UserOrders
{
    public class UserOderRepository : MongoDbRepository<PlayerMongoDbContext, UserOrder, string>, IUserOderRepository
    {
        public UserOderRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<UserOrder>> GetByGroupOrderAsync(string groupOrderId)
        {
            var collection = await GetCollectionAsync();
            var filter = Builders<UserOrder>.Filter.Eq(x => x.GroupOrderId, groupOrderId);
            var userOrders = await collection.FindAsync(filter);
            return await userOrders.ToListAsync();
        }
    }
}
