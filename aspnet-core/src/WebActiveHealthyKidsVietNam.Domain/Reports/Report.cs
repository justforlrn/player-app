using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Reports
{
    public class Report : AuditedAggregateRoot<Guid>
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
