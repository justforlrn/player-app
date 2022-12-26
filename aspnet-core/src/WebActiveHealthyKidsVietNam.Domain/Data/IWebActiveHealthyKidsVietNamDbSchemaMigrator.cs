using System.Threading.Tasks;

namespace WebActiveHealthyKidsVietNam.Data;

public interface IWebActiveHealthyKidsVietNamDbSchemaMigrator
{
    Task MigrateAsync();
}
