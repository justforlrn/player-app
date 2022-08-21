//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Volo.Abp.Domain.Repositories;
//using Volo.Abp.Identity;

//namespace Player.Users
//{
//    public interface IIdentityUserCustomRepository : IIdentityUserRepository
//    {
//        Task<bool> IsUserExistByMailAsync(List<string> emails);
//        Task<List<IdentityUser>> GetByEmailsAsync(List<string> emails);
//        Task<List<IdentityUser>> GetByIdsAsync(List<Guid> ids);
//    }
//}
