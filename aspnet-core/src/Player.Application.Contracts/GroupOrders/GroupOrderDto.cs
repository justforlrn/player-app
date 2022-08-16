using Player.UserOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.GroupOrders
{
    public class GroupOrderDto
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string RestaurantId { get; set; }
        public GroupOrderStatus Status { set; get; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        /// <summary>
        /// số tiền được giảm từ việc add mã giảm giá
        /// </summary>
        public decimal Discount { get; set; }
        public List<UserOrderDto> UserOders { set; get; }
    }
}
