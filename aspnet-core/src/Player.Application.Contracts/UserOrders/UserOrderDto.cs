using System;
using System.Collections.Generic;
using System.Text;
using Player.Groups;
using Player.Items;
using Player.Options;
using Player.Restaurants;
using Player.Users;

namespace Player.UserOrders
{
    public class UserOrderDto
    {
        public string Id { get; set; }
        public string GroupOrderId { get; set; }
        public IdentityUserDto UserDto { get; set; }
        public List<ItemAndCount> ItemAndCounts { get; set; }
        public int TotalItem { get; set; }
        public string Note { get; set; }
        public List<OptionAndCount> OptionAndCounts { get; set; }
        public int TotalOption { get; set; }
    }
}
