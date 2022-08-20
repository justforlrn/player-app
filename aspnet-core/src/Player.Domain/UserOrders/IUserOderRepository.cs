using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.UserOrders
{
    public interface IUserOderRepository : IRepository<UserOrder, string>
    {
        Task<List<UserOrder>> GetByGroupOrderAsync(string groupOrderId);
    }
}
