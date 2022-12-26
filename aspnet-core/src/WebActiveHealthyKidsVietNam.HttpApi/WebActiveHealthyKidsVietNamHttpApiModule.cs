using WebActiveHealthyKidsVietNam.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Localization.Resources.AbpUi;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(WebActiveHealthyKidsVietNamApplicationContractsModule)
    
    )]
public class WebActiveHealthyKidsVietNamHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<WebActiveHealthyKidsVietNamResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
