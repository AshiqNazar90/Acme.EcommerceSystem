using System.Threading.Tasks;

namespace Acme.EcommerceSystem.Data;

public interface IEcommerceSystemDbSchemaMigrator
{
    Task MigrateAsync();
}
