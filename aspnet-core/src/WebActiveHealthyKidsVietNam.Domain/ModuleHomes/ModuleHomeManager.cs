using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public class ModuleHomeManager : DomainService
    {
        private readonly IModuleHomeRepository _moduleHomeRepo;
        public ModuleHomeManager(IModuleHomeRepository moduleHomeRepo)
        {
            _moduleHomeRepo = moduleHomeRepo;
        }

        public async Task<ModuleHome> CreateAsync(CreateModuleHomeDto input)
        {
            var entity = new ModuleHome();
            entity.Greeting = input.Greeting;
            entity.ModuleId = input.ModuleId;
            entity.Language = input.Language;
            return await _moduleHomeRepo.InsertAsync(entity, true);
        }

        public async Task<ModuleHome> UpdateAsync(UpdateModuleHomeDto input)
        {
            var moduleHome = await _moduleHomeRepo.SingleOrDefaultAsync(x => x.Id == input.ModuleHomeId);
            if (moduleHome == null)
            {
                throw new BusinessException("Không tồn tại moduleHomeId");
            }

            moduleHome.Greeting = string.IsNullOrEmpty(input.Greeting) ? moduleHome.Greeting : input.Greeting;
            return await _moduleHomeRepo.UpdateAsync(moduleHome);
        }
    }
}
