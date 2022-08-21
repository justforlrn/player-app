using Player.Restaurants;
using Player.UserOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Player.GroupOrders
{
    public class GroupOrder : FullAuditedAggregateRoot<string>
    {
        public string GroupId { get; set; }
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } 
        public GroupOrderStatus Status { set; get; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        /// <summary>
        /// số tiền được giảm từ việc add mã giảm giá
        /// </summary>
        public decimal Discount { get; set; }
        public List<UserOder> UserOders { set; get; }
        public GroupOrder(string id, string groupId, string restaurantId, Restaurant restaurant, GroupOrderStatus status, string fromTime, string toTime, decimal discount): base(id)
        {
            Id = id;
            GroupId = groupId;
            RestaurantId = restaurantId;
            Restaurant = restaurant;
            Status = status;
            FromTime = fromTime;
            ToTime = toTime;
            Discount = discount;
            UserOders = new List<UserOrder>();
        }
    }
}
