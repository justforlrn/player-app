using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Modules;

namespace WebActiveHealthyKidsVietNam.Informations
{
    public class Information : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public string KeyName { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }
        //public Module Modules { get; set; }
        public Information(Guid id, string title, string content, string keyName, Guid moduleId, LanguageType language) : base(id)
        {
            Id = id;
            Title = title; 
            Content = content; 
            KeyName = keyName; 
            ModuleId = moduleId; 
            Language = language; 
        }
        public Information() { }
    }
}
