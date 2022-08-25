using MongoDB.Driver;
using Player.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Player.GroupOrders
{
    public class GroupOrderRepository : MongoDbRepository<PlayerMongoDbContext, GroupOrder, string>, IGroupOrderRepository
    {
        public GroupOrderRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<GroupOrder>> GetListGroupOrderByGroupId(string groupId)
		{
            var collection = await GetCollectionAsync();
            var filter = Builders<GroupOrder>.Filter.Eq(go => go.GroupId, groupId);
            var ignoreSoftDelete = Builders<GroupOrder>.Filter.Eq(e => e.IsDeleted, false);
            var finalFilter = Builders<GroupOrder>.Filter.And(new List<FilterDefinition<GroupOrder>> { filter, ignoreSoftDelete });
            var groupOrders = await collection.FindAsync(finalFilter);
            return await groupOrders.ToListAsync();
        }
    }
}
