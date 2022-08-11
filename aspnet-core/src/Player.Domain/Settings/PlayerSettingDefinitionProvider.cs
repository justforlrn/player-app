using Volo.Abp.Settings;

namespace Player.Settings;

public class PlayerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PlayerSettings.MySetting1));
    }
}
