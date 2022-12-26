using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.Repositories
{
    public class EfCoreSlideListRepository : EfCoreRepository<WebActiveHealthyKidsVietNamDbContext, SlideList>, ISlideListRepository
    {
        public EfCoreSlideListRepository(IDbContextProvider<WebActiveHealthyKidsVietNamDbContext> dbContextProvider): base(dbContextProvider)
        {

        }

        public async Task<List<SlideList>> GetAsync(Guid moduleId, LanguageType language)
        {
            IQueryable<SlideList> slideList = null;
            if (language == LanguageType.vietnam)
            {
                slideList = DbSet.Where(x => x.ModuleId == moduleId && x.Language == LanguageType.vietnam);
            }
            else
            {
                slideList = DbSet.Where(x => x.ModuleId == moduleId && x.Language == LanguageType.english);
            }
            return await slideList.OrderBy(x => x.SlideOder).ToListAsync();
        }
    }
}
