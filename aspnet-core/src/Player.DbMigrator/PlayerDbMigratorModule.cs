using Player.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Player.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PlayerMongoDbModule),
    typeof(PlayerApplicationContractsModule)
    )]
public class PlayerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
