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
    }
}
