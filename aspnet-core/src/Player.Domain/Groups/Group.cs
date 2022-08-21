using Player.GroupOrders;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Player.Groups
{
    public class Group : FullAuditedAggregateRoot<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string SecretKey { get; set; }
        public List<string> GroupOrderIds { set; get; }
        public List<IdentityUser> Members { set; get; }

        protected Group()
        {

        }
        public Group(string id, string name, string description, bool isPublic, string secretKey, List<IdentityUser> members) : base(id)
        {
            Name = name;
            Description = description;
            IsPublic = isPublic;
            SecretKey = secretKey;
            Members = members;
        }
    }
}
