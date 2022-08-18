using System;
using System.Collections.Generic;
using System.Text;

namespace Player.UserOrders
{
    public class UserOrderCreateDto
    {
        public string GroupOrderId { get; set; }
        public string RestaurantId { get; set; }

        //public string Email { get; set; }
        public List<UserOrderIdAndCountDto> ItemCountAndIds { set; get; }
        public int Count { get; set; }
        public List<UserOrderIdAndCountDto> OptionCountAndIds { set; get; }
        public string Note { get; set; }
    }
}
