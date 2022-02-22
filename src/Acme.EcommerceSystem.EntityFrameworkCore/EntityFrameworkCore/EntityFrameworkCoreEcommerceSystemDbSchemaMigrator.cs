using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.EcommerceSystem.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.EcommerceSystem.EntityFrameworkCore;

public class EntityFrameworkCoreEcommerceSystemDbSchemaMigrator
    : IEcommerceSystemDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEcommerceSystemDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the EcommerceSystemDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EcommerceSystemDbContext>()
            .Database
            .MigrateAsync();
    }
}
