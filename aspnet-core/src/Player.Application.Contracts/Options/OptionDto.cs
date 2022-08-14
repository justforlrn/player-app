//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Player.Options
//{
//    public class OptionDto
//    {
//        public string Id { get; set; }
//        public string Name { get; set; }
//        public bool IsAvailable { get; set; }
//        public decimal Price { get; set; }
//        public OptionDto(string id, string name, bool isAvailable, decimal price)
//        {
//            Id = id;
//            Name = name;
//            IsAvailable = isAvailable;
//            Price = price;
//        }
//    }

//    public class OptionGroupDto
//    {
//        public string Id { get; set; }
//        public string Name { get; set; }
//        public bool IsAvailable { get; set; }
//        public int SelectMin { get; set; }
//        public int SelectMax { get; set; }
//        public List<OptionDto> Options { get; set; }
//        public OptionGroupDto(string id, string name, bool isAvailable, int selectMin, int selectMax)
//        {
//            Id = id;
//            Name = name;
//            IsAvailable = isAvailable;
//            SelectMin = selectMin;
//            SelectMax = selectMax;
//            Options = new List<OptionDto>();
//        }
//    }
//}
