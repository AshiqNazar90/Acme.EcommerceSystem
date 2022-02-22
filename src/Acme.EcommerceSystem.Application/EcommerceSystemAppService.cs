using System;
using System.Collections.Generic;
using System.Text;
using Acme.EcommerceSystem.Localization;
using Volo.Abp.Application.Services;

namespace Acme.EcommerceSystem;

/* Inherit your application services from this class.
 */
public abstract class EcommerceSystemAppService : ApplicationService
{
    protected EcommerceSystemAppService()
    {
        LocalizationResource = typeof(EcommerceSystemResource);
    }
}
