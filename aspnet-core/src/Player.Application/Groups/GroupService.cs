using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Users;

namespace Player.Groups
{
    [RemoteService(IsEnabled = false)]
    public class GroupService : PlayerAppService, IGroupService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IGroupRepository _groupRepository;
        private readonly ICurrentUser _currentUser;
        public GroupService(IAppUserRepository appUserRepository,
            IGuidGenerator guidGenerator,
            IGroupRepository groupRepository,
            ICurrentUser currentUser)
        {
            _appUserRepository = appUserRepository;
            _guidGenerator = guidGenerator;
            _groupRepository = groupRepository;
            _currentUser = currentUser;
        }

        public async Task CreateAsync(GroupCreateDto input)
        {
            input.Emails ??= new List<string> { };
            input.Emails.Add((string)_currentUser.Email);
            input.Emails.Distinct();
            var isUserIdsExist = await _appUserRepository.IsUserExistByMailAsync(input.Emails);
            if(isUserIdsExist)
            {
                throw new BusinessException("Có userId không tồn tại");
            }
            var users = await _appUserRepository.GetByEmailsAsync(input.Emails);
            
            var group = new Group(
                id: _guidGenerator.Create().ToString(),
                name: input.Name,
                description: input.Description,
                isPublic: input.IsPublic,
                secretKey: input.IsPublic ? "" : _guidGenerator.Create().ToString(),
                members: users
                );
            await _groupRepository.InsertAsync(group);
        }

        public async Task DeleteAsync(string id)
        {
            var group = await _groupRepository.FindAsync(id);
            if(group == null)
            {
                throw new BusinessException("group không tồn tại");
            }
            await _groupRepository.DeleteAsync(group);
        }

        public async Task<List<GroupDto>> GetByCurrentAsync()
        {
            var groups = await _groupRepository.GetByUserAsync((Guid)_currentUser.Id);
            return ObjectMapper.Map<List<Group>, List<GroupDto>>(groups);
        }

        public async Task UpdateAsync(GroupUpdateDto input, string id)
        {
            var group = await _groupRepository.FindAsync(id);
            if(group == null)
            {
                throw new BusinessException("group không tồn tại");
            }
            if(input.Name != group.Name && input.Name != null)
            {
                group.Name = input.Name;    
            }
            if (input.Description != group.Description && input.Description != null)
            {
                group.Description = input.Description;
            }
            if (input.IsPublic != group.IsPublic)
            {
                group.IsPublic = input.IsPublic;
                if(group.IsPublic == true)
                {
                    group.SecretKey = "";
                }
                else
                {
                    group.SecretKey = _guidGenerator.Create().ToString();
                }
            }
            var newMembers = await _appUserRepository.GetByEmailsAsync(input.Emails);
            group.Members = newMembers;
            await _groupRepository.UpdateAsync(group);
        }
    }
}
