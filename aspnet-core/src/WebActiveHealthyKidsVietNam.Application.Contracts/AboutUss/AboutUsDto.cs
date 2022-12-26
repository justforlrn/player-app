using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.AboutUss
{
    public class AboutUsDto : AuditedEntityDto<Guid>
    {
        public string KeyName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public LanguageType Language { get; set; }
    }
}
