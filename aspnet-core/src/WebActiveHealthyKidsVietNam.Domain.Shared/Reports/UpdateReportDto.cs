using System;
using System.Collections.Generic;
using System.Text;

namespace WebActiveHealthyKidsVietNam.Reports
{
    public class UpdateReportDto
    {
        public Guid ReportId { get; set; }
        public string IndicatorIcon { get; set; }
        public string IndicatorTitle { get; set; }
        public string Benchmark { get; set; }
        public string GradeIcon { get; set; }
        public string GradeContent { get; set; }
        public string KeyFindings { get; set; }
        public string Reference { get; set; }
    }
}
