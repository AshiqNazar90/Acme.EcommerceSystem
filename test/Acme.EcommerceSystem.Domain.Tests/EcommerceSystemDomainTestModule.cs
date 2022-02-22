using Acme.EcommerceSystem.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.EcommerceSystem;

[DependsOn(
    typeof(EcommerceSystemEntityFrameworkCoreTestModule)
    )]
public class EcommerceSystemDomainTestModule : AbpModule
{

}
