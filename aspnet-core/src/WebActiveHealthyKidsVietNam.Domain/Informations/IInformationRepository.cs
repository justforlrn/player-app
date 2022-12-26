using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.Informations
{
    public interface IInformationRepository : IRepository<Information>
    {
        Task<List<Information>> GetAsync(Guid moduleId, LanguageType language);
    }
}
