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

        public async Task<List<AppUser>> GetByEmailsAsync(List<string> emails)
        {
            var collections = await GetCollectionAsync();
            var filter = Builders<AppUser>.Filter.In(x => x.Email, emails);
            var users = await (await collections.FindAsync(filter)).ToListAsync();
            return users;
        }

        public async Task<bool> IsUserExistByMailAsync(List<string> emails)
        {
            var collections = await GetCollectionAsync();
            foreach(var email in emails)
            {
                var filter = Builders<AppUser>.Filter.Eq(x => x.Email, email);
                var user = await (await collections.FindAsync(filter)).FirstAsync();
                if(user == null)
                {
                    return false;
                }
            }
            return true;          
        }
    }
}
