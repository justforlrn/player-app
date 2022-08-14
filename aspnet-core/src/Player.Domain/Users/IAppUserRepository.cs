using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.Users
{
    public interface IAppUserRepository : IRepository<AppUser, Guid>
    {
        Task<bool> IsUserIdsExistAsync(List<Guid> ids);
        Task<List<AppUser>> GetByIdsAsync(List<Guid> ids);
    }
}
