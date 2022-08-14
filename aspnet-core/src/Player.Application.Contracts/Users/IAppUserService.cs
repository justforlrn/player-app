using Player.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.Users
{
    public interface IAppUserService
    {
        Task<LoginResponseDto> Login(LoginDto loginDto);
    }
}
