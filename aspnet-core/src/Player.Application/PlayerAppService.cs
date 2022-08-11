using System;
using System.Collections.Generic;
using System.Text;
using Player.Localization;
using Volo.Abp.Application.Services;

namespace Player;

/* Inherit your application services from this class.
 */
public abstract class PlayerAppService : ApplicationService
{
    protected PlayerAppService()
    {
        LocalizationResource = typeof(PlayerResource);
    }
}
