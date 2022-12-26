using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(WebActiveHealthyKidsVietNamApplicationContractsModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule)
)]
public class WebActiveHealthyKidsVietNamHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(WebActiveHealthyKidsVietNamApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WebActiveHealthyKidsVietNamHttpApiClientModule>();
        });
    }
}
