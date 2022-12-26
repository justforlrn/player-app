using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WebActiveHealthyKidsVietNam.Data;

/* This is used if database provider does't define
 * IWebActiveHealthyKidsVietNamDbSchemaMigrator implementation.
 */
public class NullWebActiveHealthyKidsVietNamDbSchemaMigrator : IWebActiveHealthyKidsVietNamDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
