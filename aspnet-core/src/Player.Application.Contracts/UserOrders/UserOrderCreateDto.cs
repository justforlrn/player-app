using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Player.UserOrders
{
    public class UserOrderCreateDto
    {
        public string GroupOrderId { get; set; }
        public string RestaurantId { get; set; }
        [Required]
        public List<UserOrderIdAndCountDto> ItemCountAndIds { set; get; }
        public List<UserOrderIdAndCountDto> OptionCountAndIds { set; get; } = new List<UserOrderIdAndCountDto>();
        public string Note { get; set; }
    }
}
