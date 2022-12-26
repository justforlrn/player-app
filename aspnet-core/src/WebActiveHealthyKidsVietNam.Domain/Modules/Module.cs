using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;

namespace WebActiveHealthyKidsVietNam.Modules
{
    public class Module : AuditedAggregateRoot<Guid>
    {
        //public Module(Guid id, string moduleName, int order, Guid? parentId)
        //{
        //    Id = id;
        //    ModuleName = moduleName;
        //    Order = order;
        //    ParentId = parentId;
        //}

        public string ModuleName { get; set; }
        public string KeyName { get; set; }
        public Guid? ParentId { get; set; }
        public LanguageType Language { get; set; }
        //public Information Informations { get; set; }
        public Module() { }
        public Module(Guid id, string moduleName, string keyName, LanguageType languageType, Guid? parentId = null) : base(id)
        {
            Id = id;
            ModuleName = moduleName;
            KeyName = keyName;
            ParentId = parentId;
            Language = languageType;
        }
    }
}
