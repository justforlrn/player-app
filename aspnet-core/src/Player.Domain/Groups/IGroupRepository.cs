using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.Groups
{
    public interface IGroupRepository : IRepository<Group, string>
    {
        Task<List<Group>> GetByUserAsync(Guid? userId);
    }
}
