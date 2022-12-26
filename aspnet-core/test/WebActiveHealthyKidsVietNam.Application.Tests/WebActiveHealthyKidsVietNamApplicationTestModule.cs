using Volo.Abp.Modularity;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(WebActiveHealthyKidsVietNamApplicationModule),
    typeof(WebActiveHealthyKidsVietNamDomainTestModule)
    )]
public class WebActiveHealthyKidsVietNamApplicationTestModule : AbpModule
{

}
