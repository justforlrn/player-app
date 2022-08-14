using Player.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Player.Options
{
    public class OptionRepository : MongoDbRepository<PlayerMongoDbContext, Option, string>, IOptionRepository
    {
        public OptionRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
