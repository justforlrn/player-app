using MongoDB.Bson;
using MongoDB.Driver;
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

        public async Task<List<AppUser>> GetByIdsAsync(List<Guid> ids)
        {
            var collections = await GetCollectionAsync();
            var filter = Builders<AppUser>.Filter.In(x => x.Id, ids);
            var users = await (await collections.FindAsync(filter)).ToListAsync();
            return users;
        }

        public async Task<bool> IsUserIdsExistAsync(List<Guid> ids)
        {
            var collections = await GetCollectionAsync();
            foreach(var id in ids)
            {
                var filter = Builders<AppUser>.Filter.Eq(x => x.Id, id);
                var user = await (await collections.FindAsync(filter)).ToListAsync();
                if(user.Count == 0)
                {
                    return false;
                }
            }
            return true;          
        }
    }
}
