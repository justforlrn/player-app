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
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Modules;

namespace WebActiveHealthyKidsVietNam.Repositories
{
    public class EfCoreInformationRepository : EfCoreRepository<WebActiveHealthyKidsVietNamDbContext, Information>, IInformationRepository
    {
        public EfCoreInformationRepository(IDbContextProvider<WebActiveHealthyKidsVietNamDbContext> dbContextProvider): base(dbContextProvider)
        {

        }

        public async Task<List<Information>> GetAsync(Guid moduleId, LanguageType language)
        {
            if(language == LanguageType.vietnam)
            {
                return await DbSet.Where(x => x.ModuleId == moduleId && x.Language == LanguageType.vietnam).ToListAsync();
            }
            else
            {
                return await DbSet.Where(x => x.ModuleId == moduleId && x.Language == LanguageType.english).ToListAsync();
            }
        }
    }
}
