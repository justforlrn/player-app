using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public interface IModuleHomeRepository : IRepository<ModuleHome>
    {
        Task<ModuleHomeEntity> GetHomePage(LanguageType language);
    }
}
