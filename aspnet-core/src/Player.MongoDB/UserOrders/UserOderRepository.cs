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
    public class UserOderRepository : MongoDbRepository<PlayerMongoDbContext, UserOder, string>, IUserOderRepository
    {
        public UserOderRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
