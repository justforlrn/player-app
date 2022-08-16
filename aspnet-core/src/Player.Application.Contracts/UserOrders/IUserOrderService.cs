using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.UserOrders
{
    public interface IUserOrderService
    {
        Task<UserOrderDto> GetAsync(string id);
        Task<List<UserOrderDto>> GetByGroupOrder(string groupOrderId);
        Task CreateAsync(UserOrderCreateDto input);
        Task UpdateAsync(UserOrderUpdateDto input);
        Task DeleteAsync(string id);
    }
}
