using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.Services
{
    public interface ISlideListService
    {
        Task<SlideListDto> CreateAsync(CreateSlideListDto input);
        Task<List<SlideListDto>> GetAsync(Guid moduleId, LanguageType language);
        Task<SlideListDto> UpdateAsync(UpdateSlideListDto input);
    }
}
