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

        [HttpPost]
        public async Task CreateAsync([FromBody] UserOrderCreateDto input)
        {
            await _userOrderService.CreateAsync(input);
        }
    }
}
