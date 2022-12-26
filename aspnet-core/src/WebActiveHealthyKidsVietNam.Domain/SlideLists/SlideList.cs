using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.SlideLists
{
    public class SlideList : AuditedAggregateRoot<Guid>
    {
        public string SlideTitle { get; set; }
        public string SlideContent { get; set; }
        public SlideType SlideType { get; set; }
        public string ImageUrl { get; set; }
        public int SlideOder { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }
    }
}
