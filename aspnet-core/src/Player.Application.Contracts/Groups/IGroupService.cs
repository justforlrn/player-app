using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.Groups
{
    public interface IGroupService
    {
        Task CreateAsync(GroupCreateDto input);
    }
}
