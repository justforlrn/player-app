using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace WebActiveHealthyKidsVietNam.Informations
{
    public class InformationManager : DomainService
    {
        private readonly IInformationRepository _informationRepo;
        public InformationManager(IInformationRepository informationRepo)
        {
            _informationRepo = informationRepo;
        }

        public async Task<Information> CreateAsync(CreateInformationDto input)
        {
            var entity = new Information();
            entity.Title = input.Title;
            entity.Content = input.Content;
            entity.Icon = input.Icon;
            entity.KeyName = input.KeyName;
            entity.ModuleId = input.ModuleId;
            entity.Language = input.Language;
            return await _informationRepo.InsertAsync(entity, true);
        }

        public async Task<Information> UpdateAsync(UpdateInformationDto input)
        {
            var information = await _informationRepo.SingleOrDefaultAsync(x => x.Id == input.InformationId);
            if (information == null)
            {
                throw new BusinessException("Không tồn tại ìnormationId");
            }

            information.Title = string.IsNullOrEmpty(input.Title) ? information.Title : input.Title;
            information.Content = string.IsNullOrEmpty(input.Content) ? information.Content : input.Content;
            information.Icon = string.IsNullOrEmpty(input.Icon) ? information.Icon : input.Icon;
            information.KeyName = string.IsNullOrEmpty(input.KeyName) ? information.KeyName : input.KeyName;
            return await _informationRepo.UpdateAsync(information);
        }
    }
}
