using Player.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Player.Restaurants
{
    public class Restaurant : FullAuditedAggregateRoot<string>
    {
        public string Name { get; set; }
        public int Star { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }
        public List<Item> Items { set; get; }
    }
}
