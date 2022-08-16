using Player.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.OptionGroups
{
    public class OptionGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int SelectMin { get; set; }
        public int SelectMax { get; set; }
        public List<Option> Options { get; set; }
        public OptionGroup(string id, string name, bool isAvailable, int selectMin, int selectMax)
        {
            Id = id;
            Name = name;
            IsAvailable = isAvailable;
            SelectMin = selectMin;
            SelectMax = selectMax;
            Options = new List<Option>();
        }
    }
}
