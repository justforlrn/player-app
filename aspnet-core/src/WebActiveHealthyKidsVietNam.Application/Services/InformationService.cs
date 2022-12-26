using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.Services
{
    [RemoteService(false)]
    public class InformationService : WebActiveHealthyKidsVietNamAppService, IInformationService
    {
        private readonly InformationManager _informationManager;
        private readonly IInformationRepository _informationRepo;

        public InformationService(
            InformationManager informationManager,
            IInformationRepository informationRepo)
        {
            _informationManager = informationManager;
            _informationRepo = informationRepo;
        }

        public async Task<InformationDto> CreateAsync(CreateInformationDto input)
        {
            var entity = await _informationManager.CreateAsync(input);
            return ObjectMapper.Map<Information, InformationDto>(entity);
        }

        public async Task<List<InformationDto>> GetAsync(Guid moduleId, LanguageType language)
        {
            var slideList = await _informationRepo.GetAsync(moduleId, language);
            return ObjectMapper.Map<List<Information>, List<InformationDto>>(slideList);
        }

        public async Task<InformationDto> UpdateAsync(UpdateInformationDto input)
        {
            var entity = await _informationManager.UpdateAsync(input);
            return ObjectMapper.Map<Information, InformationDto>(entity);
        }
    }
}
