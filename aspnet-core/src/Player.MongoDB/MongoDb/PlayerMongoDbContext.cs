using MongoDB.Driver;
using Player.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Player.MongoDB;

[ConnectionStringName("Default")]
public class PlayerMongoDbContext : AbpMongoDbContext
{

    public IMongoCollection<AppUser> AppUsers => Collection<AppUser>();
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);
        modelBuilder.Entity<AppUser>(b =>
        {
            b.CollectionName = "AbpUsers"; //Sets the collection name
        });
        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
