using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Modules
{
    public interface IModuleRepository : IRepository<Module>
    {
        Task<List<Module>> GetAsync(LanguageType language);
    }
}
