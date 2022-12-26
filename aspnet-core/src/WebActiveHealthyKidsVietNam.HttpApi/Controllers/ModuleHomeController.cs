using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Controllers;
using WebActiveHealthyKidsVietNam.ModuleHomes;
using WebActiveHealthyKidsVietNam.Services;

namespace WebActiveHealthyKids.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/modulehome")]
    public class ModuleHomeController : WebActiveHealthyKidsVietNamController
    {
        private readonly IModuleHomeService _moduleHomeService;
        public ModuleHomeController(IModuleHomeService moduleHomeService)
        {
            _moduleHomeService = moduleHomeService;
        }

        [HttpPost]
        public async Task<ModuleHomeDto> CreateAsync(CreateModuleHomeDto input)
        {
            return await _moduleHomeService.CreateAsync(input);
        }

        [HttpPut]
        public async Task<ModuleHomeDto> UpdateAsync(UpdateModuleHomeDto input)
        {
            return await _moduleHomeService.UpdateAsync(input);
        }

        [HttpGet("gethomepage")]
        public async Task<GetHomePageDto> GetHomePage(LanguageType language)
        {
            return await _moduleHomeService.GetHomePage(language);
        }
    }
}
