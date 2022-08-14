using Player.MongoDB;
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
    }
}
