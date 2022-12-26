using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Controllers;
using WebActiveHealthyKidsVietNam.Services;

namespace WebActiveHealthyKids.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/aboutus")]
    [Authorize]
    public class AboutUsController : WebActiveHealthyKidsVietNamController
    {
        private readonly IAboutUsService _aboutUsSer;

        public AboutUsController(IAboutUsService aboutUsSer)
        {
            _aboutUsSer = aboutUsSer;
        }


        /// <summary>
        /// api tạo aboutUs
        /// </summary>
        /// <param name="input">
        /// <h5>0:VietNam</h5>
        /// <h5>1:English</h5>
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AboutUsDto> CreateAsync(CreateAboutUsDto input)
        {
            return await _aboutUsSer.CreateAsync(input);
        }

        /// <summary>
        /// api chỉnh sửa aboutUs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<AboutUsDto> UpdateAsync(UpdateAboutUsDto input)
        {
            return await _aboutUsSer.UpdateAsync(input);
        }

        /// <summary>
        /// api get list aboutUs
        /// </summary>
        /// <param name="language">
        /// <h5>0:VietNam</h5>
        /// <h5>1:English</h5>
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AboutUsDto>> GetAsync(LanguageType language)
        {
            return await _aboutUsSer.GetAsync(language);
        }
    }
}
