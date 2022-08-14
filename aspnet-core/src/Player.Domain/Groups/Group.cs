using Player.GroupOrders;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Player.Groups
{
    public class Group : FullAuditedAggregateRoot<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string SecretKey { get; set; }
        public List<GroupOrder> GroupOrders { set; get; }
        public List<AppUser> Members { set; get; }
        
    }
}
