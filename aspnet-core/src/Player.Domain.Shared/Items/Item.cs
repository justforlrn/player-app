using Player.OptionGroups;
using Player.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Items
{
    /// <summary>
    /// các món ăn của 1 nhà hàng
    /// </summary>
    public class Item
    {
        public string Id { get; set; }
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
        //public string RestaurantId { get; set; }
        public List<OptionGroup> OptionGroups { get; set; }
        public Item(string id, string name, string imageUrl, decimal priceOrigin, decimal priceDiscount)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            PriceOrigin = priceOrigin;
            PriceDiscount = priceDiscount;
            OptionGroups = new List<OptionGroup>();
        }
    }
}
