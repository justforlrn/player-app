using Microsoft.AspNetCore.Mvc;
using Player.UserOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Player.Controllers.AppControllers
{
    [Route("user-order")]
    [IgnoreAntiforgeryToken]
    public class UserOrderController : AbpController
    {
        private readonly IUserOrderService _userOrderService;
        public UserOrderController(IUserOrderService userOrderService)
        {
            _userOrderService = userOrderService;
        }

        [HttpGet("{id}")]
        public async Task<UserOrderDto> GetAsync(string id)
        {
            return await _userOrderService.GetAsync(id);
        }

        [HttpGet("group-order/{groupOrderId}")]
        public async Task<List<UserOrderDto>> GetByGroupOrderAsync(string groupOrderId)
        {
            return await _userOrderService.GetByGroupOrderAsync(groupOrderId);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] UserOrderCreateDto input)
        {
            await _userOrderService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync([FromBody] UserOrderUpdateDto input, string id)
        {
            await _userOrderService.UpdateAsync(input, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _userOrderService.DeleteAsync(id);
        }
    }
}
