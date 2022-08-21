using System;
using System.Collections.Generic;
using System.Text;
using Player.Groups;
using Player.Items;
using Player.Options;
using Player.Restaurants;
using Player.Users;
using Volo.Abp.Identity;

namespace Player.UserOrders
{
    public class UserOrderDto
    {
        public string GroupOrderId{ get; set; }
        public IdentityUserDto IdentityUser { get; set; }
        public List<Item> Items { get; set; }
        public int Count { get; set; }
        public string Note { get; set; }
    }
}
