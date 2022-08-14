using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Player.Options
{
    /// <summary>
    /// các tùy chọn thêm khi đặt món
    /// </summary>
    public class Option : FullAuditedAggregateRoot<string>
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public string ItemId { get; set; }
    }
}
