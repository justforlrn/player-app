using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Player.Data;

/* This is used if database provider does't define
 * IPlayerDbSchemaMigrator implementation.
 */
public class NullPlayerDbSchemaMigrator : IPlayerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
