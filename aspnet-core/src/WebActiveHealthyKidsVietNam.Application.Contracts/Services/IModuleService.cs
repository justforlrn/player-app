using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Modules;

namespace WebActiveHealthyKidsVietNam.Services
{
    public interface IModuleService
    {
        Task<ModuleDto> CreateAsync(CreateModuleDto input);
        Task<List<ModuleDto>> GetAsync(LanguageType language);
    }
}
