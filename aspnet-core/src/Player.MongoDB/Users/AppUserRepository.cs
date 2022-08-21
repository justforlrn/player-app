//using MongoDB.Bson;
//using MongoDB.Driver;
//using Player.MongoDB;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Volo.Abp.Domain.Repositories.MongoDB;
//using Volo.Abp.Identity;
//using Volo.Abp.MongoDB;

//namespace Player.Users
//{
//    public class IdentityUserRepository : MongoDbRepository<PlayerMongoDbContext, IdentityUser, Guid>, IIdentityUserCustomRepository
//    {
//        public IdentityUserRepository(IMongoDbContextProvider<PlayerMongoDbContext> dbContextProvider) : base(dbContextProvider)
//        {
//        }

//        public async Task<List<IdentityUser>> GetByIdsAsync(List<Guid> ids)
//        {
//            var collections = await GetCollectionAsync();
//            var filter = Builders<IdentityUser>.Filter.In(x => x.Id, ids);
//            var users = await (await collections.FindAsync(filter)).ToListAsync();
//            return users;
//        }

//        public async Task<List<IdentityUser>> GetByEmailsAsync(List<string> emails)
//        {
//            var collections = await GetCollectionAsync();
//            var filter = Builders<IdentityUser>.Filter.In(x => x.Email, emails);
//            var users = await (await collections.FindAsync(filter)).ToListAsync();
//            return users;
//        }

//        public async Task<bool> IsUserExistByMailAsync(List<string> emails)
//        {
//            var collections = await GetCollectionAsync();
//            foreach(var email in emails)
//            {
//                var filter = Builders<IdentityUser>.Filter.Eq(x => x.Email, email);
//                var user = await (await collections.FindAsync(filter)).FirstAsync();
//                if(user == null)
//                {
//                    return false;
//                }
//            }
//            return true;          
//        }

//        public Task<IdentityUser> FindByNormalizedUserNameAsync(string normalizedUserName, bool includeDetails = true, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<string>> GetRoleNamesAsync(Guid id, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<string>> GetRoleNamesInOrganizationUnitAsync(Guid id, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IdentityUser> FindByLoginAsync(string loginProvider, string providerKey, bool includeDetails = true, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IdentityUser> FindByNormalizedEmailAsync(string normalizedEmail, bool includeDetails = true, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityUser>> GetListByClaimAsync(Claim claim, bool includeDetails = false, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityUser>> GetListByNormalizedRoleNameAsync(string normalizedRoleName, bool includeDetails = false, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityUser>> GetListAsync(string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, bool includeDetails = false, Guid? roleId = null, Guid? organizationUnitId = null, string userName = null, string phoneNumber = null, string emailAddress = null, bool? isLockedOut = null, bool? notActive = null, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityRole>> GetRolesAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityUser>> GetUsersInOrganizationUnitAsync(Guid organizationUnitId, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityUser>> GetUsersInOrganizationsListAsync(List<Guid> organizationUnitIds, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<IdentityUser>> GetUsersInOrganizationUnitWithChildrenAsync(string code, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<long> GetCountAsync(string filter = null, Guid? roleId = null, Guid? organizationUnitId = null, string userName = null, string phoneNumber = null, string emailAddress = null, bool? isLockedOut = null, bool? notActive = null, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
