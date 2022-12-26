using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace WebActiveHealthyKidsVietNam;

[Dependency(ReplaceServices = true)]
public class WebActiveHealthyKidsVietNamBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "WebActiveHealthyKidsVietNam";
}
