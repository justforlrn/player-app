using System;
using System.Collections.Generic;
using System.Text;

namespace Player.UserOrders
{
    public class UserOrderItemAndOptionWithCountDto
    {
        public List<ItemAndCount> ItemAndCounts { set; get; }
        public List<OptionAndCount> OptionAndCounts { set; get; }

    }
}
