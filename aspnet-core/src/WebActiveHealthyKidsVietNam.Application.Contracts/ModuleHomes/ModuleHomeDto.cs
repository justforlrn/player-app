using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public class ModuleHomeDto : AuditedEntityDto<Guid>
    {
        public string Greeting { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }
    }
}
