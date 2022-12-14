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
        public string ImageUrl { get; set; }
        public string WebUrl { get; set; }
        public List<Item> Items { set; get; }
        public Restaurant(string id, string name, int star, string open, string close, string imageUrl, string webUrl): base(id)
        {
            Id = id;
            Name = name;
            Star = star;
            Open = open;
            Close = close;
            ImageUrl = imageUrl;
            WebUrl = webUrl;
            Items = new List<Item>();
        }
        public Restaurant() { }
    }
}
