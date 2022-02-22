using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.EcommerceSystem.Data;

/* This is used if database provider does't define
 * IEcommerceSystemDbSchemaMigrator implementation.
 */
public class NullEcommerceSystemDbSchemaMigrator : IEcommerceSystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
