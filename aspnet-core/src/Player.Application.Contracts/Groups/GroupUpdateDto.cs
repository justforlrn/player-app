using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Groups
{
    public class GroupUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public List<string> Emails { set; get; }
    }
}
