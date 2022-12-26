using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Controllers;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.Services;

namespace WebActiveHealthyKids.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/module")]
    public class ModuleController : WebActiveHealthyKidsVietNamController
    {
        private readonly IModuleService _moduleSer;

        public ModuleController (IModuleService moduleSer)
        {
            _moduleSer = moduleSer;
        }

        [HttpPost]
        public async Task<ModuleDto> CreateAsync(CreateModuleDto input)
        {
            return await _moduleSer.CreateAsync(input);
        }

        [HttpGet]
        public async Task<List<ModuleDto>> GetAsync(LanguageType language)
        {
            return await _moduleSer.GetAsync(language);
        }
    }
}
