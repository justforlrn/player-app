using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Controllers;
using WebActiveHealthyKidsVietNam.Services;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKids.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/slidelist")]
    public class SlideListController : WebActiveHealthyKidsVietNamController
    {
        private readonly ISlideListService _slideListSer;

        public SlideListController(ISlideListService slideListSer)
        {
            _slideListSer = slideListSer;
        }

        /// <summary>
        /// api tạo banner, slides, publication, event
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SlideListDto> CreateAsync([FromBody] CreateSlideListDto input)
        {
            return await _slideListSer.CreateAsync(input);
        }

        [HttpPut]
        public async Task<SlideListDto> UpdateAsync(UpdateSlideListDto input)
        {
            return await _slideListSer.UpdateAsync(input);
        }

        [HttpGet]
        public async Task<List<SlideListDto>> GetAsync(Guid moduleId, LanguageType language)
        {
            return await _slideListSer.GetAsync(moduleId, language);
        }
    }
}
