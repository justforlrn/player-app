using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(WebActiveHealthyKidsVietNamDomainSharedModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class WebActiveHealthyKidsVietNamApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        WebActiveHealthyKidsVietNamDtoExtensions.Configure();
    }
}
