using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.Services
{
    public interface IInformationService
    {
        Task<InformationDto> CreateAsync(CreateInformationDto input);
        Task<List<InformationDto>> GetAsync(Guid moduleId, LanguageType language);
        Task<InformationDto> UpdateAsync(UpdateInformationDto input);
    }
}
