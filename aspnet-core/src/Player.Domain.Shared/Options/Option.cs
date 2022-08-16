using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Options
{
    /// <summary>
    /// các tùy chọn thêm khi đặt món
    /// </summary>
    public class Option
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public Option(string id, string name, bool isAvailable, decimal price)
        {
            Id = id;
            Name = name;
            IsAvailable = isAvailable;
            Price = price;
        }
    }
}
