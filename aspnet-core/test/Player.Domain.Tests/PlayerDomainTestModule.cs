using Player.MongoDB;
using Volo.Abp.Modularity;

namespace Player;

[DependsOn(
    typeof(PlayerMongoDbTestModule)
    )]
public class PlayerDomainTestModule : AbpModule
{

}
