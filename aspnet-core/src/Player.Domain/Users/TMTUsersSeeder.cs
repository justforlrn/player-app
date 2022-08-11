using IdentityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Player.Users
{
    public class TMTUsersSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;
        public TMTUsersSeeder(IIdentityUserRepository identityUserRepository, IdentityUserManager identityUserManager)
        {
            _identityUserRepository = identityUserRepository;
            _identityUserManager = identityUserManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            string path = Directory.GetCurrentDirectory().Split("\\bin")[0];
            var stream = await File.ReadAllLinesAsync($"{path}\\contact-list.csv");
            //var userList = new List<IdentityUser>();
            for(int i = 0; i < stream.Length; i++)
            {
                //Name: 2, Sex: 3, Meil: 8, SDT: 9, skype: 11
                var data = stream[i].Split(",");
                if(data.Length > 8)
                {
                    var newUser = new IdentityUser(Guid.NewGuid(), data[8] == "" ? $"{Guid.NewGuid()}@unknown.unknown" : data[8], data[8] == "" ? $"{Guid.NewGuid()}@unknown.unknown" : data[8]);
                    newUser.SetPhoneNumber(data.Length >= 10 ? data[9] : null, data.Length >= 10 ? true : false);
                    newUser.Name = data[2];
                    newUser.SetProperty("Sex", data[3]);
                    newUser.SetProperty("Skype", data.Length >= 12 ? data[11] : null);
                    await _identityUserManager.CreateAsync(newUser, "123", false);
                }
            }
        }
    }
}
