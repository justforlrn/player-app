using System;
using System.Collections.Generic;
using System.Text;

namespace Player.GroupOrders
{
    public class CreateGroupOrderDto
    {
        public string GroupId { get; set; }
        public string RestaurantId { get; set; }
        public CreateGroupOrderDto(string groupId, string restaurantId)
        {
            GroupId = groupId;
            RestaurantId = restaurantId;
        }
    }
}
