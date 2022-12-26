using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Informations
{
    public class UpdateInformationDto
    {
        public Guid InformationId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public string KeyName { get; set; }
    }
}
