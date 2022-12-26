using AutoMapper;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.ModuleHomes;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.Reports;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam;

public class WebActiveHealthyKidsVietNamApplicationAutoMapperProfile : Profile
{
    public WebActiveHealthyKidsVietNamApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Module, ModuleDto>();
        CreateMap<AboutUs, AboutUsDto>();
        CreateMap<ModuleHome, ModuleHomeDto>();
        CreateMap<ModuleHomeEntity, GetHomePageDto>();
        CreateMap<Information, InformationDto>();
        CreateMap<SlideList, SlideListDto>();
        CreateMap<Report, ReportDto>();
    }
}
