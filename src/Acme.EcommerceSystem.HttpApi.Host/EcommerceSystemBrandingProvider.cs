using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.EcommerceSystem;

[Dependency(ReplaceServices = true)]
public class EcommerceSystemBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EcommerceSystem";
}
