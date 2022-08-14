using Player.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Player.Users
{
    public class AppUserRepository : MongoDbRepository<PlayerMongoDbContext, AppUser, Guid>, IAppUserRepository
    {
        public AppUserRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
