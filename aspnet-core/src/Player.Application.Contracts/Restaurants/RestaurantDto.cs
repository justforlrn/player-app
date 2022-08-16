using Player.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Restaurants
{
    public class RestaurantDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Star { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }
        public string ImageUrl { get; set; }
        public string WebUrl { get; set; }
        public List<Item> Items { get; set; }
        public RestaurantDto(string id, string name, int star, string open, string close, string imageUrl, string webUrl)
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
        public RestaurantDto() { }
    }
}
