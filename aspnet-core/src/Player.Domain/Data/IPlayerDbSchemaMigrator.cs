using System.Threading.Tasks;

namespace Player.Data;

public interface IPlayerDbSchemaMigrator
{
    Task MigrateAsync();
}
