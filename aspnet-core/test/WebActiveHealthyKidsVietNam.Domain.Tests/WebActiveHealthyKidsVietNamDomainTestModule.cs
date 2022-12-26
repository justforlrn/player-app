using WebActiveHealthyKidsVietNam.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(WebActiveHealthyKidsVietNamEntityFrameworkCoreTestModule)
    )]
public class WebActiveHealthyKidsVietNamDomainTestModule : AbpModule
{

}
