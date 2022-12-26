using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Commons;
using WebActiveHealthyKidsVietNam.Informations;

namespace WebActiveHealthyKidsVietNam.Services
{
    public interface IAboutUsService
    {
        Task<AboutUsDto> CreateAsync(CreateAboutUsDto input);
        Task<AboutUsDto> UpdateAsync(UpdateAboutUsDto input);
        Task<List<AboutUsDto>> GetAsync(LanguageType language);
    }
}
