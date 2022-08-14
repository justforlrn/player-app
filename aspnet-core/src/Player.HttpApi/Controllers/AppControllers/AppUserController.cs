﻿using Microsoft.AspNetCore.Mvc;
using Player.Users;
using Player.Users.DTOs;
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
        [HttpPost("login")]
        public async Task<LoginResponseDto> LoginAsync([FromBody] LoginDto input)
        {
            return await _appUserService.Login(input);
        }
    }
}
