using Player.AppUsers.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.AppUsers
{
    public interface IAppUserService
    {
        Task Login(LoginDto loginDto);
    }
}
