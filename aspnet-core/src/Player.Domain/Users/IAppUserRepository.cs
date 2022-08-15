using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.Users
{
    public interface IAppUserRepository : IRepository<AppUser, Guid>
    {
        Task<bool> IsUserExistByMailAsync(List<string> emails);
        Task<List<AppUser>> GetByEmailsAsync(List<string> emails);
        Task<List<AppUser>> GetByIdsAsync(List<Guid> ids);
    }
}
