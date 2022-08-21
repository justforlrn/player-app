using Player.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;

namespace Player.GroupOrders
{
    [RemoteService(IsEnabled = false)]
    public class GroupOrderService: PlayerAppService, IGroupOrderService
    {
        private readonly IGroupOrderRepository _groupOrderRepository;
        private readonly IRestaurantService _restaurantService;
        public GroupOrderService(IGroupOrderRepository groupOrderRepository, IRestaurantService restaurantService)
        {
            _groupOrderRepository = groupOrderRepository;
            _restaurantService = restaurantService;
        }
        public async Task<GroupOrderDto> CreateOrderGroupAsync(CreateGroupOrderDto input)
        {
            var restaurant = ObjectMapper.Map<RestaurantDto, Restaurant>(await _restaurantService.Cache_Get(input.RestaurantId));
            var groupOrder = new GroupOrder(
                id: Guid.NewGuid().ToString(),
                groupId: input.GroupId,
                restaurantId: input.RestaurantId,
                restaurant: restaurant,
                status: GroupOrderStatus.open,
                fromTime: DateTime.Now.ToLongDateString(),
                toTime: DateTime.Now.ToLongDateString(),
                discount: 0);
            await _groupOrderRepository.InsertAsync(groupOrder);
            return ObjectMapper.Map<GroupOrder, GroupOrderDto>(groupOrder);
        }
        public async Task<List<GroupOrderDto>> GetListGroupOrderByGroupId(string groupId)
		{
            var groupOrders = await _groupOrderRepository.GetListGroupOrderByGroupId(groupId);
            var result = ObjectMapper.Map<List<GroupOrder>, List<GroupOrderDto>>(groupOrders);
            //for(int i = 0; i < result.Count; i++)
            //{
            //    result[i].Restaurant = await _restaurantService.Cache_Get(result[i].RestaurantId);
            //};
            return result;
        }
    }
}
