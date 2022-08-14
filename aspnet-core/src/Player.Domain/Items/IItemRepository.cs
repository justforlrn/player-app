using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Player.Items
{
    public interface IItemRepository : IRepository<Item, string>
    {
    }
}
