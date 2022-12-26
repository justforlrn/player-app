using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Reports;

namespace WebActiveHealthyKidsVietNam.Services
{
    [RemoteService(false)]
    public class ReportService : WebActiveHealthyKidsVietNamAppService, IReportService
    {
        private readonly ReportManager _reportManager;
        private readonly IReportRepository _reportRepo;

        public ReportService(
            ReportManager reportManager, IReportRepository reportRepo)
        {
            _reportManager = reportManager;
            _reportRepo = reportRepo;
        }

        public async Task<ReportDto> CreateAsync(CreateReportDto input)
        {
            var entity = await _reportManager.CreateAsync(input);
            return ObjectMapper.Map<Report, ReportDto>(entity);
        }

        public async Task<List<ReportDto>> GetAsync(LanguageType language)
        {
            var listAboutUs = await _reportRepo.GetAsync(language);
            return ObjectMapper.Map<List<Report>, List<ReportDto>>(listAboutUs);
        }

        public async Task<ReportDto> UpdateAsync(UpdateReportDto input)
        {
            var entity = await _reportManager.UpdateAsync(input);
            return ObjectMapper.Map<Report, ReportDto>(entity);
        }
    }
}
