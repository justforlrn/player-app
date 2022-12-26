using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public class CreateModuleHomeDto
    {
        public string Greeting { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }
    }
}
