using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.Auths;

namespace WebActiveHealthyKidsVietNam.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/auths")]
    public class AuthController: WebActiveHealthyKidsVietNamController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }
        [Authorize]
        [HttpPost("change-password")]
        public async Task ChangePasswordAsync([FromBody] ChangePasswordDto dto)
        {
            await _authService.ChangePasswordAsync(dto);
        }
        [HttpPost("sign-in")]
        public async Task<SignInResultDto> SignInAsync([FromBody]SignInDto dto)
        {
            return await _authService.SignInAsync(dto);
        }
        [HttpPost("user-create")]
        public async Task UserCreateAsync([FromBody]UserCreateDto dto)
        {
             await _authService.UserCreateAsync(dto);
        }
    }
}
