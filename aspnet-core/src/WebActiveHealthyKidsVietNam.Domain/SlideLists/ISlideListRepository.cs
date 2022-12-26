using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.SlideLists
{
    public interface ISlideListRepository : IRepository<SlideList>
    {
        Task<List<SlideList>> GetAsync(Guid moduleId, LanguageType language);
    }
}
