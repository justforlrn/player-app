using Microsoft.AspNetCore.Mvc;
using Player.AppUsers;
using Player.AppUsers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Player.Controllers.AppControllers
{

    [Route("users")]
    public class AppUserController : AbpController
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpPost]
        public async Task LoginAsync([FromBody] LoginDto input)
        {
            await _appUserService.Login(input);
        }
    }
}
