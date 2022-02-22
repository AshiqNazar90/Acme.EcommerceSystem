using Acme.EcommerceSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.EcommerceSystem.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EcommerceSystemController : AbpControllerBase
{
    protected EcommerceSystemController()
    {
        LocalizationResource = typeof(EcommerceSystemResource);
    }
}
