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
using WebActiveHealthyKidsVietNam.Reports;

namespace WebActiveHealthyKidsVietNam.Repositories
{
    public class EfCoreReportRepository : EfCoreRepository<WebActiveHealthyKidsVietNamDbContext, Report>, IReportRepository
    {
        public EfCoreReportRepository(IDbContextProvider<WebActiveHealthyKidsVietNamDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Report>> GetAsync(LanguageType language)
        {
            if (language == LanguageType.vietnam)
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
