using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Player.GroupOrders
{
    [RemoteService(IsEnabled = false)]
    public class GroupOrderService: PlayerAppService, IGroupOrderService
    {
        private readonly IGroupOrderRepository _groupOrderRepository;
        public GroupOrderService(IGroupOrderRepository groupOrderRepository)
        {
            _groupOrderRepository = groupOrderRepository;
        }
        public async Task<GroupOrderDto> CreateOrderGroupAsync(CreateGroupOrderDto input)
        {
            var groupOrder = new GroupOrder(
                id: Guid.NewGuid().ToString(),
                groupId: input.GroupId,
                restaurantId: input.RestaurantId,
                status: GroupOrderStatus.open,
                fromTime: DateTime.Now.ToLongDateString(),
                toTime: DateTime.Now.ToLongDateString(),
                discount: 0);
            await _groupOrderRepository.InsertAsync(groupOrder);
            return ObjectMapper.Map<GroupOrder, GroupOrderDto>(groupOrder);
        }
    }
}
