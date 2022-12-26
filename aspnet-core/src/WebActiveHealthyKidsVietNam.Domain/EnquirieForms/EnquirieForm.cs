using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace WebActiveHealthyKidsVietNam.EnquirieForms
{
    public class EnquirieForm : AuditedAggregateRoot<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Affiliation { get; set; }
        public string Content { get; set; }
    }
}
