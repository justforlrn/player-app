﻿using MongoDB.Driver;
using Player.MongoDB;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Player.Groups
{
    public class GroupRepository : MongoDbRepository<PlayerMongoDbContext, Group, string>, IGroupRepository
    {
        public GroupRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Group>> GetByUserAsync(Guid userId)
        {
            var collection = await GetCollectionAsync();
            var filter = Builders<Group>.Filter.ElemMatch(x => x.Members, e => e.Id == userId);
            var groups = await collection.FindAsync(filter);
            return await groups.ToListAsync();
        }
    }
}
