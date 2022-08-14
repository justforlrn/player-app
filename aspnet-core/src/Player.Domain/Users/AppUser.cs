using Volo.Abp.Identity;

namespace Player.Users
{
    public class AppUser : IdentityUser
    {
        public string LinkSkype { get; set; }
        public string Sex { get; set; }
    }
}