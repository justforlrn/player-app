using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Player;

[Dependency(ReplaceServices = true)]
public class PlayerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Player";
}
