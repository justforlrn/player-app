using WebActiveHealthyKidsVietNam.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule)    
    )]
public class WebActiveHealthyKidsVietNamDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        WebActiveHealthyKidsVietNamGlobalFeatureConfigurator.Configure();
        WebActiveHealthyKidsVietNamModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WebActiveHealthyKidsVietNamDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<WebActiveHealthyKidsVietNamResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/WebActiveHealthyKidsVietNam");

            options.DefaultResourceType = typeof(WebActiveHealthyKidsVietNamResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("WebActiveHealthyKidsVietNam", typeof(WebActiveHealthyKidsVietNamResource));
        });
    }
}
