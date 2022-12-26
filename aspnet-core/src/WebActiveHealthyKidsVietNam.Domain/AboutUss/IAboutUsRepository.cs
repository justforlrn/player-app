using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.AboutUss
{
    public interface IAboutUsRepository : IRepository<AboutUs>
    {
        Task<List<AboutUs>> GetAsync(LanguageType language);
    }
}
