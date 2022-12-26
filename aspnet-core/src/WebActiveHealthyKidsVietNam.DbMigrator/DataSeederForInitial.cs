using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Modules;

namespace WebActiveHealthyKidsVietNam.DbMigrator
{
    public class DataSeederForInitial : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Module, Guid> _moduleRepository;
        private readonly IRepository<Information, Guid> _informationRepository;
        private readonly IGuidGenerator _guidGenerator;

        public DataSeederForInitial(
            IRepository<Module, Guid> moduleRepository,
            IRepository<Information, Guid> informationRepository,
            IGuidGenerator guidGenerator)
        {
            _moduleRepository = moduleRepository;
            _informationRepository = informationRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _moduleRepository.GetCountAsync() > 0)
            {
                return;
            }

            var eventModule = new Module(_guidGenerator.Create(), "event", "event", Commons.LanguageType.vietnam);

            await _moduleRepository.InsertAsync(eventModule);

            var eventIn = new Information(_guidGenerator.Create(), "", "", "event", eventModule.Id, Commons.LanguageType.vietnam);

            await _informationRepository.InsertAsync(eventIn);

            var publicationModule = new Module(_guidGenerator.Create(), "publication", "publication", Commons.LanguageType.vietnam);

            await _moduleRepository.InsertAsync(publicationModule);

            var publication = new Information(_guidGenerator.Create(), "", "", "publication", publicationModule.Id, Commons.LanguageType.vietnam);

            await _informationRepository.InsertAsync(publication);

            var reportcard2022Module = new Module(_guidGenerator.Create(), "reportcard2022", "reportcard2022", Commons.LanguageType.vietnam);

            await _moduleRepository.InsertAsync(reportcard2022Module);

            var reportcard2022 = new Information(_guidGenerator.Create(), "", "", "reportcard2022", reportcard2022Module.Id, Commons.LanguageType.vietnam);

            await _informationRepository.InsertAsync(reportcard2022);

            var homeModule = new Module(_guidGenerator.Create(), "home", "home", Commons.LanguageType.vietnam);

            await _moduleRepository.InsertAsync(homeModule);

            var introduction = new Information(_guidGenerator.Create(), "", "", "introduction", homeModule.Id, Commons.LanguageType.vietnam);

            await _informationRepository.InsertAsync(introduction);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            var eventModuleEng = new Module(_guidGenerator.Create(), "event", "event", Commons.LanguageType.english);

            await _moduleRepository.InsertAsync(eventModuleEng);

            var eventInEng = new Information(_guidGenerator.Create(), "", "", "event", eventModuleEng.Id, Commons.LanguageType.english);

            await _informationRepository.InsertAsync(eventInEng);

            var publicationModuleEng = new Module(_guidGenerator.Create(), "publication", "publication", Commons.LanguageType.english);

            await _moduleRepository.InsertAsync(publicationModuleEng);

            var publicationEng = new Information(_guidGenerator.Create(), "", "", "publication", publicationModuleEng.Id, Commons.LanguageType.english);

            await _informationRepository.InsertAsync(publicationEng);

            var reportcard2022ModuleEng = new Module(_guidGenerator.Create(), "reportcard2022", "reportcard2022", Commons.LanguageType.english);

            await _moduleRepository.InsertAsync(reportcard2022ModuleEng);

            var reportcard2022Eng = new Information(_guidGenerator.Create(), "", "", "reportcard2022", reportcard2022ModuleEng.Id, Commons.LanguageType.english);

            await _informationRepository.InsertAsync(reportcard2022Eng);

            var homeModuleEng = new Module(_guidGenerator.Create(), "home", "home", Commons.LanguageType.english);

            await _moduleRepository.InsertAsync(homeModuleEng);

            var introductionEng = new Information(_guidGenerator.Create(), "", "", "introduction", homeModuleEng.Id, Commons.LanguageType.english);

            await _informationRepository.InsertAsync(introductionEng);
        }
    }
}