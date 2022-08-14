using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Player.Groups
{
    public interface IGroupService
    {
        Task<List<GroupDto>> GetByCurrentAsync();
        Task CreateAsync(GroupCreateDto input);
        Task UpdateAsync(GroupUpdateDto input, string id);
        Task DeleteAsync(string id);
    }
}
