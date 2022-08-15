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
        public Group Group { get; set; }
        public AppUser User { get; set; }
        public List<Item> Items { get; set; }
        public int Count { get; set; }
        public List<Option> Options { set; get; }
        public string Note { get; set; }
        public UserOder(Group group, AppUser user, List<Item> items, int count, List<Option> options, string note)
        {
            Group = group;
            User = user;
            Items = items;
            Count = count;

            Options = options;
            Note = note;
        }
    }
}
