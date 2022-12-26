using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.ModuleHomes;

namespace WebActiveHealthyKidsVietNam.Services
{
    [RemoteService(false)]
    public class ModuleHomeService : WebActiveHealthyKidsVietNamAppService, IModuleHomeService
    {
        private readonly ModuleHomeManager _moduleHomeManager;
        private readonly IModuleHomeRepository _moduleHomeRepo;

        public ModuleHomeService(
            ModuleHomeManager moduleHomeManager,
            IModuleHomeRepository moduleHomeRepo)
        {
            _moduleHomeManager = moduleHomeManager;
            _moduleHomeRepo = moduleHomeRepo;
        }

        public async Task<ModuleHomeDto> CreateAsync(CreateModuleHomeDto input)
        {
            var entity = await _moduleHomeManager.CreateAsync(input);
            return ObjectMapper.Map<ModuleHome, ModuleHomeDto>(entity);
        }

        public async Task<ModuleHomeDto> UpdateAsync(UpdateModuleHomeDto input)
        {
            var entity = await _moduleHomeManager.UpdateAsync(input);
            return ObjectMapper.Map<ModuleHome, ModuleHomeDto>(entity);
        }

        public async Task<GetHomePageDto> GetHomePage(LanguageType language)
        {
            var homePage = await _moduleHomeRepo.GetHomePage(language);
            var result = ObjectMapper.Map<ModuleHomeEntity, GetHomePageDto>(homePage);
            return result;
        }
    }
}
