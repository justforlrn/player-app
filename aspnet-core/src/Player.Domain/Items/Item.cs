using Player.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Player.Items
{
    /// <summary>
    /// các món ăn của 1 nhà hàng
    /// </summary>
    public class Item : FullAuditedAggregateRoot<string>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// giá gốc
        /// </summary>
        public decimal PriceOrigin { get; set; }
        /// <summary>
        /// giá giảm
        /// </summary>
        public decimal PriceDiscount { get; set; }
        public string RestaurantId { get; set; }
        public List<Option> Options { get; set; }
    }
}
