using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Localization;
using Volo.Abp.Application.Services;

namespace WebActiveHealthyKidsVietNam;

/* Inherit your application services from this class.
 */
public abstract class WebActiveHealthyKidsVietNamAppService : ApplicationService
{
    protected WebActiveHealthyKidsVietNamAppService()
    {
        LocalizationResource = typeof(WebActiveHealthyKidsVietNamResource);
    }
}
