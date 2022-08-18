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

namespace Player.UserOrders
{
    public class UserOder : FullAuditedAggregateRoot<string>
    {
        public string GroupOrderId { get; set; }
        public AppUser User { get; set; }
        public List<ItemAndCount> ItemAndCounts { get; set; }
        public int TotalItem { get; set; }
        public string Note { get; set; }
        public List<OptionAndCount> OptionAndCounts { get; set; }
        public int TotalOption { get; set; }

        public UserOder(string groupOrderId, AppUser user, List<ItemAndCount> itemAndCounts, int totalItem, string note, List<OptionAndCount> optionAndCounts, int totalOption)
        {
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
