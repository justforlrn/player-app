using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using WebActiveHealthyKidsVietNam.Modules;

namespace WebActiveHealthyKidsVietNam.SlideLists
{
    public class SlideListManager : DomainService
    {
        private readonly ISlideListRepository _slideListRepo;
        public SlideListManager(ISlideListRepository slideListRepo)
        {
            _slideListRepo = slideListRepo;
        }

        public async Task<SlideList> CreateAsync(CreateSlideListDto input)
        {
            var entity = new SlideList();
            entity.SlideTitle = input.SlideTitle;
            entity.SlideContent = input.SlideContent;
            entity.SlideType = input.SlideType;
            entity.ImageUrl = input.ImageUrl;
            entity.SlideOder = input.SlideOder;
            entity.ModuleId = input.ModuleId;
            entity.Language = input.Language;
            return await _slideListRepo.InsertAsync(entity);
        }

        public async Task<SlideList> UpdateAsync(UpdateSlideListDto input)
        {
            var slide = await _slideListRepo.SingleOrDefaultAsync(x => x.Id == input.SlideId);
            if (slide == null)
            {
                throw new BusinessException("Không tồn tại SlideId");
            }

            slide.SlideTitle = string.IsNullOrEmpty(input.SlideTitle) ? slide.SlideTitle : input.SlideTitle;
            slide.SlideContent = string.IsNullOrEmpty(input.SlideContent) ? slide.SlideContent : input.SlideContent;
            slide.SlideType = input.SlideType == null ? slide.SlideType : input.SlideType;
            slide.ImageUrl = string.IsNullOrEmpty(input.ImageUrl) ? slide.ImageUrl : input.ImageUrl;
            slide.SlideOder = input.SlideOder == null ? slide.SlideOder : input.SlideOder;
            return await _slideListRepo.UpdateAsync(slide);
        }
    }
}
