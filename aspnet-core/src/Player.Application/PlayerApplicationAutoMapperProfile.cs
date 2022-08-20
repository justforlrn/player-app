using AutoMapper;
using Player.GroupOrders;
using Player.Items;
using Player.Options;
using Player.Restaurants;
using Player.Groups;
using Player.Users;
using Player.UserOrders;
using Volo.Abp.Identity;

namespace Player;

public class PlayerApplicationAutoMapperProfile : Profile
{
    public PlayerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Restaurant, RestaurantDto>();
        CreateMap<GroupOrder, GroupOrderDto>();
        CreateMap<Group, GroupDto>();
        CreateMap<IdentityUser, Users.IdentityUserDto>();   
    }
}
