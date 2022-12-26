using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;

namespace WebActiveHealthyKidsVietNam.Services
{
    [RemoteService(false)]
    public class AboutUsService : WebActiveHealthyKidsVietNamAppService, IAboutUsService
    {
        private readonly AboutUsManager _aboutUsManager;
        private readonly IAboutUsRepository _aboutUsRepo;

        public AboutUsService(
            AboutUsManager aboutUsManager,
            IAboutUsRepository aboutUsRepo)
        {
            _aboutUsManager = aboutUsManager;
            _aboutUsRepo = aboutUsRepo;
        }

        public async Task<AboutUsDto> CreateAsync(CreateAboutUsDto input)
        {
            var entity = await _aboutUsManager.CreateAsync(input);
            return ObjectMapper.Map<AboutUs, AboutUsDto>(entity);
        }

        public async Task<List<AboutUsDto>> GetAsync(LanguageType language)
        {
            var listAboutUs = await _aboutUsRepo.GetAsync(language);
            return ObjectMapper.Map<List<AboutUs>, List<AboutUsDto>>(listAboutUs);
        }

        public async Task<AboutUsDto> UpdateAsync(UpdateAboutUsDto input)
        {
            var entity = await _aboutUsManager.UpdateAsync(input);
            return ObjectMapper.Map<AboutUs, AboutUsDto>(entity);
        }
    }
}
