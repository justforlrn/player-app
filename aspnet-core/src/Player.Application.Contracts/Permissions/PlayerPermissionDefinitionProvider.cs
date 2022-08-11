using Player.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Player.Permissions;

public class PlayerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PlayerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PlayerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PlayerResource>(name);
    }
}
