using System;
using System.Collections.Generic;
using System.Text;
using Player.UserOrders;

namespace Player.UserOrders
{
    public class UserOrderDto
    {
        public string GroupId { get; set; }
        public string UserEmail { get; set; }
        public List<Item> Items { get; set; }
        public int Count { get; set; }
        public List<Option> Options { set; get; }
        public string Note { get; set; }
    }
}
