using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.EntityFrameworkCore;

namespace WebActiveHealthyKidsVietNam.Repositories
{
    public class EfCoreAboutUsRepository : EfCoreRepository<WebActiveHealthyKidsVietNamDbContext, AboutUs>, IAboutUsRepository
    {
        public EfCoreAboutUsRepository(IDbContextProvider<WebActiveHealthyKidsVietNamDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        [Obsolete]
        public async Task<List<AboutUs>> GetAsync(LanguageType language)
        {
            if(language == LanguageType.vietnam)
            {
                return await DbSet.Where(x => x.Language == LanguageType.vietnam).ToListAsync();
            }
            else
            {
                return await DbSet.Where(x => x.Language == LanguageType.english).ToListAsync();
            }
        }
    }
}
