using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.SlideLists
{
    public class SlideListDto : AuditedEntityDto<Guid>
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
