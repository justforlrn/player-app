using WebActiveHealthyKidsVietNam.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WebActiveHealthyKidsVietNam.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WebActiveHealthyKidsVietNamController : AbpControllerBase
{
    protected WebActiveHealthyKidsVietNamController()
    {
        LocalizationResource = typeof(WebActiveHealthyKidsVietNamResource);
    }
}
