using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Reports;
using WebActiveHealthyKidsVietNam.Services;

namespace WebActiveHealthyKidsVietNam.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/reports")]
    public class ReportController : WebActiveHealthyKidsVietNamController
    {
        private readonly IReportService _reportSer;

        public ReportController(IReportService reportSer)
        {
            _reportSer = reportSer;
        }

        [HttpPost]
        public async Task<ReportDto> CreateAsync([FromBody]CreateReportDto input)
        {
            return await _reportSer.CreateAsync(input);
        }

        [HttpPut]
        public async Task<ReportDto> UpdateAsync(UpdateReportDto input)
        {
            return await _reportSer.UpdateAsync(input);
        }

        [HttpGet]
        public async Task<List<ReportDto>> GetAsync(LanguageType language)
        {
            return await _reportSer.GetAsync(language);
        }
    }
}
