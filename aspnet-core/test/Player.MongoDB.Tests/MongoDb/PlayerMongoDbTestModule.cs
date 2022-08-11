using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Player.MongoDB;

[DependsOn(
    typeof(PlayerTestBaseModule),
    typeof(PlayerMongoDbModule)
    )]
public class PlayerMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = PlayerMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
