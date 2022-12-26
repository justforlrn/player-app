using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.Services
{
    [RemoteService(false)]
    public class SlideListService : WebActiveHealthyKidsVietNamAppService, ISlideListService
    {
        private readonly SlideListManager _slideListManager;
        private readonly ISlideListRepository _slideListRepo;

        public SlideListService(
            SlideListManager slideListManager,
            ISlideListRepository slideListRepo)
        {
            _slideListManager = slideListManager;
            _slideListRepo = slideListRepo;
        }

        public async Task<SlideListDto> CreateAsync(CreateSlideListDto input)
        {
            var entity = await _slideListManager.CreateAsync(input);
            return ObjectMapper.Map<SlideList, SlideListDto>(entity);
        }

        public async Task<List<SlideListDto>> GetAsync(Guid moduleId, LanguageType language)
        {
            var slideList = await _slideListRepo.GetAsync(moduleId, language);
            return ObjectMapper.Map<List<SlideList>, List<SlideListDto>>(slideList);
        }

        public async Task<SlideListDto> UpdateAsync(UpdateSlideListDto input)
        {
            var entity = await _slideListManager.UpdateAsync(input);
            return ObjectMapper.Map<SlideList, SlideListDto>(entity);
        }
    }
}
