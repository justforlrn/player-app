using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Informations
{
    public class InformationDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public string KeyName { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }

    }
}
