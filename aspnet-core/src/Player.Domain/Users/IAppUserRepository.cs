using System;
using Volo.Abp.Domain.Repositories;

namespace Player.Users
{
    public interface IAppUserRepository : IRepository<AppUser, Guid>
    {
    }
}
