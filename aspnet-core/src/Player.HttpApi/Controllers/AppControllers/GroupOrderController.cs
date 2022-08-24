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

        [HttpGet("get-list-by-group-id")]
        public async Task<List<GroupOrderDto>> GetListGroupOrderByGroupId(string groupId)
        {
            return await _groupOrderService.GetListGroupOrderByGroupId(groupId);
        }

        [HttpGet]
        public async Task<GroupOrderDto> GetAsync(string groupOrderId)
        {
            return await _groupOrderService.GetAsync(groupOrderId);
        }

        [HttpDelete]
        public async Task DeleteAsync(string id)
        {
            await _groupOrderService.DeleteAsync(id);
        }
    }
}
