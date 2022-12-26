using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace WebActiveHealthyKidsVietNam.Modules
{
    public class ModuleManager : DomainService
    {
        private readonly IModuleRepository _moduleRep;

        public ModuleManager(IModuleRepository moduleRepo)
        {
            _moduleRep = moduleRepo;
        }

        public async Task<Module> CreateAsync(CreateModuleDto input)
        {
            var moduleEntity = new Module();
            moduleEntity.ModuleName = input.ModuleName;
            moduleEntity.KeyName = input.KeyName;
            moduleEntity.ParentId = input.ParentId;
            moduleEntity.Language = input.Language;
            return await _moduleRep.InsertAsync(moduleEntity);
        }
    }
}
