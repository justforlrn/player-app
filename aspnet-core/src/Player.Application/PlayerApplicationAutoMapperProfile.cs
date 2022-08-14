using AutoMapper;
using Player.Groups;

namespace Player;

public class PlayerApplicationAutoMapperProfile : Profile
{
    public PlayerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Group, GroupDto>();
    }
}
