using WebActiveHealthyKidsVietNam.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace WebActiveHealthyKidsVietNam.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WebActiveHealthyKidsVietNamEntityFrameworkCoreModule),
    typeof(WebActiveHealthyKidsVietNamApplicationContractsModule)
    )]
public class WebActiveHealthyKidsVietNamDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
