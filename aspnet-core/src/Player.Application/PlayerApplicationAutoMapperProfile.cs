using AutoMapper;
using Player.GroupOrders;
using Player.Items;
using Player.Options;
using Player.Restaurants;

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
        //CreateMap<Item, ItemDto>();
        //CreateMap<ItemDto, Item>();
        //CreateMap<Option, OptionDto>();
    }
}
