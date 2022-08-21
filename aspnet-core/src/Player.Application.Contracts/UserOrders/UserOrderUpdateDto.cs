using System;
using System.Collections.Generic;
using System.Text;

namespace Player.UserOrders
{
    public class UserOrderUpdateDto
    {
        public string RestaurantId { get; set; }
        public List<UserOrderIdAndCountDto> ItemCountAndIds { set; get; }
        public List<UserOrderIdAndCountDto> OptionCountAndIds { set; get; }
        public string Note { get; set; }
    }
}

