using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Modules;

namespace WebActiveHealthyKidsVietNam.Services
{
    [RemoteService(false)]
    public class ModuleService : WebActiveHealthyKidsVietNamAppService, IModuleService
    {
        private readonly ModuleManager _moduleManager;
        private readonly IModuleRepository _moduleRepo;

        public ModuleService(ModuleManager moduleManager, IModuleRepository moduleRepo)
        {
            _moduleManager = moduleManager;
            _moduleRepo = moduleRepo;
        }

        public async Task<ModuleDto> CreateAsync(CreateModuleDto input)
        {
            var moduleEntity = await _moduleManager.CreateAsync(input);
            return ObjectMapper.Map<Module, ModuleDto>(moduleEntity);
        }

        public async Task<List<ModuleDto>> GetAsync(LanguageType language)
        {
            var moduleEntity = await _moduleRepo.GetAsync(language);
            return ObjectMapper.Map<List<Module>, List<ModuleDto>>(moduleEntity);
        }
    }
}
