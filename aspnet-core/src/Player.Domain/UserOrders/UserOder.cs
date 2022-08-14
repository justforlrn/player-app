using Player.Items;
using Player.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Player.UserOrders
{
    public class UserOder : FullAuditedAggregateRoot<string>
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public int Count { get; set; }
        public List<Option> Options { set; get; }
        public string Note { get; set; }
    }
}
