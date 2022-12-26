using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.ModuleHomes;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.Reports;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.Repositories
{
    public class EfCoreModuleHomeRepository : EfCoreRepository<WebActiveHealthyKidsVietNamDbContext, ModuleHome>, IModuleHomeRepository
    {
        public EfCoreModuleHomeRepository(IDbContextProvider<WebActiveHealthyKidsVietNamDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        [Obsolete]
        public async Task<ModuleHomeEntity> GetHomePage(LanguageType language)
        {
            Guid moduleId;
            string greeting = null;
            IQueryable<Information> informations = null;
            IQueryable<Report> indicators = null;
            if (language == LanguageType.vietnam)
            {
                moduleId = DbContext.Modules.FirstOrDefault(x => x.ModuleName == "Trang chủ").Id;
                greeting = DbSet.FirstOrDefault(x => x.ModuleId == moduleId && x.Language == LanguageType.vietnam).Greeting;
                informations = DbContext.Informations.Where(x => x.ModuleId == moduleId && x.Language == LanguageType.vietnam);
                indicators = DbContext.Reports.Where(x => x.Language == LanguageType.vietnam);
            }
            else
            {
                moduleId = DbContext.Modules.FirstOrDefault(x => x.ModuleName == "Home").Id;
                greeting = DbSet.FirstOrDefault(x => x.ModuleId == moduleId && x.Language == LanguageType.english).Greeting;
                informations = DbContext.Informations.Where(x => x.ModuleId == moduleId && x.Language == LanguageType.english);
                indicators = DbContext.Reports.Where(x => x.Language == LanguageType.english);
            }
            var slides = DbContext.SlideLists.Where(x => x.ModuleId == moduleId);

            var result = new ModuleHomeEntity()
            {
                Banners = slides.Where(x => x.SlideType == SlideType.Banner).ToList(),
                Slides = slides.Where(x => x.SlideType == SlideType.Slide).ToList(),
                Greeting = greeting,
                Informations = informations.ToList(),
                Indicators = indicators.ToList()
            };
            return result;
        }
    }
}
