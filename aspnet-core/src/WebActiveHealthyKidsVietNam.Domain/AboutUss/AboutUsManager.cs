using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using WebActiveHealthyKidsVietNam.Informations;

namespace WebActiveHealthyKidsVietNam.AboutUss
{
    public class AboutUsManager : DomainService
    {
        private readonly IAboutUsRepository _aboutUsRepo;
        public AboutUsManager(IAboutUsRepository aboutUsRepo)
        {
            _aboutUsRepo = aboutUsRepo;
        }

        public async Task<AboutUs> CreateAsync(CreateAboutUsDto input)
        {
            var entity = new AboutUs();
            entity.KeyName = input.KeyName;
            entity.Title = input.Title;
            entity.Content = input.Content;
            entity.Language = input.Language;
            return await _aboutUsRepo.InsertAsync(entity, true);
        }

        public async Task<AboutUs> UpdateAsync(UpdateAboutUsDto input)
        {
            var aboutUs = await _aboutUsRepo.SingleOrDefaultAsync(x => x.Id == input.AboutUsId);
            if (aboutUs == null)
            {
                throw new BusinessException("Không tồn tại aboutUsId");
            }

            aboutUs.KeyName = string.IsNullOrEmpty(input.KeyName) ? aboutUs.KeyName : input.KeyName;
            aboutUs.Title = string.IsNullOrEmpty(input.Title) ? aboutUs.Title : input.Title;
            aboutUs.Content = string.IsNullOrEmpty(input.Content) ? aboutUs.Content : input.Content;
            return await _aboutUsRepo.UpdateAsync(aboutUs);
        }
    }
}
