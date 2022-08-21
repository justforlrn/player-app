using MongoDB.Driver;
using Player.GroupOrders;
using Player.Groups;
using Player.Items;
using Player.Options;
using Player.Restaurants;
using Player.UserOrders;
using Player.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Player.MongoDB;

[ConnectionStringName("Default")]
public class PlayerMongoDbContext : AbpMongoDbContext
{

    public IMongoCollection<AppUser> AppUsers => Collection<AppUser>();
    public IMongoCollection<Group> Groups => Collection<Group>();
    public IMongoCollection<GroupOrder> GroupOrders => Collection<GroupOrder>();
    //public IMongoCollection<Item> Items => Collection<Item>();
    //public IMongoCollection<Option> Options => Collection<Option>();
    public IMongoCollection<Restaurant> Restaurants => Collection<Restaurant>();
    public IMongoCollection<UserOrder> UserOders => Collection<UserOrder>();


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

        modelBuilder.Entity<Group>(b =>
        {
            b.CollectionName = "Groups";
        });
        modelBuilder.Entity<GroupOrder>(b =>
        {
            b.CollectionName = "GroupOrders";
        });
        //modelBuilder.Entity<Item>(b =>
        //{
        //    b.CollectionName = "Items";
        //});
        //modelBuilder.Entity<Option>(b =>
        //{
        //    b.CollectionName = "Options";
        //});
        modelBuilder.Entity<Restaurant>(b =>
        {
            b.CollectionName = "Restaurants";
        });
        modelBuilder.Entity<UserOrder>(b =>
        {
            b.CollectionName = "UserOders";
        });
    }
}
