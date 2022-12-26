using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using WebActiveHealthyKidsVietNam.Informations;

namespace WebActiveHealthyKidsVietNam.Reports
{
    public class ReportManager : DomainService
    {
        private readonly IReportRepository _reportRepo;
        public ReportManager(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public async Task<Report> CreateAsync(CreateReportDto input)
        {
            var entity = new Report();
            entity.IndicatorIcon= input.IndicatorIcon;
            entity.IndicatorTitle = input.IndicatorTitle;
            entity.Benchmark = input.Benchmark;
            entity.GradeIcon = input.GradeIcon;
            entity.GradeContent = input.GradeContent;
            entity.KeyFindings = input.KeyFindings;
            entity.Reference = input.Reference;
            entity.Language = input.Language;
            return await _reportRepo.InsertAsync(entity);
        }

        public async Task<Report> UpdateAsync(UpdateReportDto input)
        {
            var report = await _reportRepo.SingleOrDefaultAsync(x => x.Id == input.ReportId);
            if (report == null)
            {
                throw new BusinessException("Không tồn tại reportId");
            }

            report.IndicatorIcon = string.IsNullOrEmpty(input.IndicatorIcon) ? report.IndicatorIcon : input.IndicatorIcon;
            report.IndicatorTitle = string.IsNullOrEmpty(input.IndicatorTitle) ? report.IndicatorTitle : input.IndicatorTitle;
            report.Benchmark = string.IsNullOrEmpty(input.Benchmark) ? report.Benchmark : input.Benchmark;
            report.GradeIcon = string.IsNullOrEmpty(input.GradeIcon) ? report.GradeIcon : input.GradeIcon;
            report.GradeContent = string.IsNullOrEmpty(input.GradeContent) ? report.GradeContent : input.GradeContent;
            report.KeyFindings = string.IsNullOrEmpty(input.KeyFindings) ? report.KeyFindings : input.KeyFindings;
            report.Reference = string.IsNullOrEmpty(input.Reference) ? report.Reference : input.Reference;
            return await _reportRepo.UpdateAsync(report);
        }
    }
}
