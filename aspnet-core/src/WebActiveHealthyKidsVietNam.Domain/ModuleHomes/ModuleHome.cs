using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public class ModuleHome : AuditedAggregateRoot<Guid>
    {
        public string Greeting { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }
    }
}
