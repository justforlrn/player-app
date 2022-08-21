using Player.Groups;
using Player.Items;
using Player.Options;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Player.UserOrders
{
    public class UserOrder : FullAuditedAggregateRoot<string>
    {
        public string GroupOrderId { get; set; }
        public IdentityUser User { get; set; }
        public List<ItemAndCount> ItemAndCounts { get; set; }
        public int TotalItem { get; set; }
        public string Note { get; set; }
        public List<OptionAndCount> OptionAndCounts { get; set; }
        public int TotalOption { get; set; }

        public UserOrder(string id, string groupOrderId, IdentityUser user, List<ItemAndCount> itemAndCounts, int totalItem, string note, List<OptionAndCount> optionAndCounts, int totalOption)
        {
            Id = id;
            GroupOrderId = groupOrderId;
            User = user;
            ItemAndCounts = itemAndCounts;
            TotalItem = totalItem;
            Note = note;
            OptionAndCounts = optionAndCounts;
            TotalOption = totalOption;
        }
    }
}
