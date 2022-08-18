using System;
using System.Collections.Generic;
using System.Text;

namespace Player.UserOrders
{
    public class UserOrderUpdateDto
    {
        public string GroupOrderId { get; set; }
        //public string Email { get; set; }
        public List<string> ItemIds { get; set; }
        public int Count { get; set; }
        public List<string> OptionIds { set; get; }
        public string Note { get; set; }
    }
}

