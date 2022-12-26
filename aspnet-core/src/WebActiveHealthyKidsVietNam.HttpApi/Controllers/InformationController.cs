using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Controllers;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Services;

namespace WebActiveHealthyKids.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/information")]
    public class InformationController : WebActiveHealthyKidsVietNamController
    {
        private readonly IInformationService _informationSer;

        public InformationController(IInformationService informationSer)
        {
            _informationSer = informationSer;
        }

        [HttpPost]
        public async Task<InformationDto> CreateAsync([FromBody] CreateInformationDto input)
        {
            return await _informationSer.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<InformationDto> UpdateAsync([FromBody] UpdateInformationDto input)
        {
            return await _informationSer.UpdateAsync(input);
        }

        [HttpGet]
        public async Task<List<InformationDto>> GetAsync(Guid moduleId, LanguageType language)
        {
            return await _informationSer.GetAsync(moduleId, language);
        }
    }
}
