using Acme.EcommerceSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Acme.EcommerceSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EcommerceSystemEntityFrameworkCoreModule),
    typeof(EcommerceSystemApplicationContractsModule)
    )]
public class EcommerceSystemDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
