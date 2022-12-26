using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Modules
{
    public class CreateModuleDto
    {
        public string ModuleName { get; set; }
        public string KeyName { get; set; }
        public Guid? ParentId { get; set; }
        public LanguageType Language { get; set; }
    }
}
