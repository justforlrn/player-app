using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Reports
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<List<Report>> GetAsync(LanguageType language);
    }
}
