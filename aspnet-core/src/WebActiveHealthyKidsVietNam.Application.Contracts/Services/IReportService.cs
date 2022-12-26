using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Reports;

namespace WebActiveHealthyKidsVietNam.Services
{
    public interface IReportService
    {
        Task<ReportDto> CreateAsync(CreateReportDto input);
        Task<List<ReportDto>> GetAsync(LanguageType language);
        Task<ReportDto> UpdateAsync(UpdateReportDto input);
    }
}
