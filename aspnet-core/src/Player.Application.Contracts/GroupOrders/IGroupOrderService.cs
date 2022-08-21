using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.GroupOrders
{
    public interface IGroupOrderService
    {
        Task<GroupOrderDto> CreateOrderGroupAsync(CreateGroupOrderDto input);
        Task<List<GroupOrderDto>> GetListGroupOrderByGroupId(string groupId);
    }
}
