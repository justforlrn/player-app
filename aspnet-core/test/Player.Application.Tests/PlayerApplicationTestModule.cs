using Volo.Abp.Modularity;

namespace Player;

[DependsOn(
    typeof(PlayerApplicationModule),
    typeof(PlayerDomainTestModule)
    )]
public class PlayerApplicationTestModule : AbpModule
{

}
