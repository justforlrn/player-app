using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Modules
{
    public class ModuleDto : AuditedEntityDto<Guid>
    {
        public string ModuleName { get; set; }
        public string KeyName { get; set; }
        public Guid? ParentId { get; set; }
        public LanguageType Language { get; set; }
    }
}
