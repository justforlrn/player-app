﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Reports
{
    public class ReportDto : AuditedEntityDto<Guid>
    {
        public string IndicatorIcon { get; set; }
        public string IndicatorTitle { get; set; }
        public string Benchmark { get; set; }
        public string GradeIcon { get; set; }
        public string GradeContent { get; set; }
        public string KeyFindings { get; set; }
        public string Reference { get; set; }
        public LanguageType Language { get; set; }
    }
}
