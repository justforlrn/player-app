using Player.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Player.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PlayerController : AbpControllerBase
{
    protected PlayerController()
    {
        LocalizationResource = typeof(PlayerResource);
    }
}
