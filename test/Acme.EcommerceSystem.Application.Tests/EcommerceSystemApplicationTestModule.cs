using Volo.Abp.Modularity;

namespace Acme.EcommerceSystem;

[DependsOn(
    typeof(EcommerceSystemApplicationModule),
    typeof(EcommerceSystemDomainTestModule)
    )]
public class EcommerceSystemApplicationTestModule : AbpModule
{

}
