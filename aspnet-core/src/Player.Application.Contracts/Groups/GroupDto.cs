using Player.GroupOrders;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Groups
{
    public class GroupDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string SecretKey { get; set; }
        public List<GroupOrderDto> GroupOrders { set; get; }
        public List<IdentityUserDto> Members { set; get; }
    }
}
