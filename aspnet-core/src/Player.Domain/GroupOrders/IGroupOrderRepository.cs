﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.GroupOrders
{
    public interface IGroupOrderRepository : IRepository<GroupOrder, string>
    {
        Task<List<GroupOrder>> GetListGroupOrderByGroupId(string groupId);
    }
}
