using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Informations
{
    public class CreateInformationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public string KeyName { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }

    }
}
