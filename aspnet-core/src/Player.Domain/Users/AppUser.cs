using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Player.Users
{
    public class AppUser : IdentityUser
    {
        public string LinkSkype { get; set; }
        public string Sex { get; set; }
    }
}