using Microsoft.AspNetCore.Mvc;
using Player.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Player.Controllers.AppControllers
{
    [Route("groups")]
    [IgnoreAntiforgeryToken]
    public class GroupController : AbpController
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("get-by-current")]
        public async Task<List<GroupDto>> GetByCurrentAsync()
        {
            return await _groupService.GetByCurrentAsync();
        }

        [HttpPost]
        public async Task CreateAsync([FromBody]GroupCreateDto input)
        {
           await _groupService.CreateAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DelateAsync(string id)
        {
            await _groupService.DeleteAsync(id);
        }


    }
   
}
