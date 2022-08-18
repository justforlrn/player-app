using Microsoft.AspNetCore.Mvc;
using Player.GroupOrders;
using Player.Restaurants;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Player.Controllers.AppControllers
{
    [Route("group-orders")]
    public class GroupOrderController : AbpController
    {
        private readonly IGroupOrderService _groupOrderService;
        public GroupOrderController(IGroupOrderService groupOrderService)
        {
            _groupOrderService = groupOrderService;
        }
        [HttpPost]
        public async Task<GroupOrderDto> CreateAsync([FromBody] CreateGroupOrderDto input)
        {
            return await _groupOrderService.CreateOrderGroupAsync(input);
        }
    }
}
