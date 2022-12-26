using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.AboutUss
{
    public class AboutUs : AuditedAggregateRoot<Guid>
    {
        public string KeyName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public LanguageType Language { get; set; }
    }
}
