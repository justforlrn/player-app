using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.ModuleHomes;

namespace WebActiveHealthyKidsVietNam.Services
{
    public interface IModuleHomeService
    {
        Task<ModuleHomeDto> CreateAsync(CreateModuleHomeDto input);
        Task<GetHomePageDto> GetHomePage(LanguageType language);
        Task<ModuleHomeDto> UpdateAsync(UpdateModuleHomeDto input);
    }
}
