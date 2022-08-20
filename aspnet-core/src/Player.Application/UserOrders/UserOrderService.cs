using Player.GroupOrders;
using Player.Items;
using Player.Restaurants;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Player.UserOrders
{
    [RemoteService(IsEnabled = false)]
    public class UserOrderService : PlayerAppService, IUserOrderService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IUserOderRepository _userOrderRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IGroupOrderRepository _groupOrderRepository;

        public UserOrderService(
            IRestaurantRepository restaurantRepository,
            ICurrentUser currentUser,
            IIdentityUserRepository identityUserRepository,
            IUserOderRepository userOrderRepository,
            IGuidGenerator guidGenerator,
            IGroupOrderRepository groupOrderRepository
            )
        {
            _restaurantRepository = restaurantRepository;
            _currentUser = currentUser;
            _identityUserRepository = identityUserRepository;
            _userOrderRepository = userOrderRepository;
            _guidGenerator = guidGenerator;
            _groupOrderRepository = groupOrderRepository;
        }

        private UserOrderDto MapUserOrderToDto(UserOrder userOrder)
        {
            return new UserOrderDto
            {
                Id = userOrder.Id,
                GroupOrderId = userOrder.GroupOrderId,
                UserDto = ObjectMapper.Map<IdentityUser, Users.IdentityUserDto>(userOrder.User),
                ItemAndCounts = userOrder.ItemAndCounts,
                TotalItem = userOrder.TotalItem,
                Note = userOrder.Note,
                OptionAndCounts = userOrder.OptionAndCounts,
                TotalOption = userOrder.TotalOption
            };
        }
        private UserOrderItemAndOptionWithCountDto CheckAndGetItemsAndOptionsWithCount
            (
                Restaurant restaurant,
                List<UserOrderIdAndCountDto> itemCountAndIds,
                List<UserOrderIdAndCountDto> optionCountAndIds
            )
        {
            var itemIdsByRestaurant = restaurant.Items.Select(x => x.Id).ToList();
            var itemIdsInput = itemCountAndIds.Select(x => x.Id).ToList();
            itemIdsInput.Distinct();
            var itemIdsNotExist = itemIdsInput.Except(itemIdsByRestaurant).ToList();
            if (itemIdsNotExist.Count != 0)
            {
                throw new BusinessException("Danh sách có chứa món ăn không tồn tại");
            }
            var itemBooks = restaurant.Items.Where(x => itemIdsInput.Contains(x.Id)).ToList();

            var itemAndCounts = new List<ItemAndCount>();
            var optionAndCounts = new List<OptionAndCount>();

            foreach (var itemBook in itemBooks)
            {
                //if(!itemBook.IsAvailable)
                //{
                //    throw new BusinessException("item không có sẵn");
                //}
                var itemAndCount = new ItemAndCount
                {
                    Item = new Item(itemBook.Id, itemBook.Name, itemBook.ImageUrl, itemBook.PriceOrigin, itemBook.PriceDiscount),
                    Count = itemCountAndIds.FirstOrDefault(x => x.Id == itemBook.Id).Count
                };
                itemAndCounts.Add(itemAndCount);
                if(optionCountAndIds != null && optionCountAndIds?.Count != 0)
                {
                    var optionInputIds = optionCountAndIds.Select(x => x.Id).ToList();
                    optionInputIds.Distinct();
                
                    foreach (var optionGroup in itemBook.OptionGroups)
                    {
                        var options = optionGroup.Options.Where(x => optionInputIds.Contains(x.Id)).ToList();
                        if(options.Count > 0)
                        {
                            foreach (var option in options)
                            {
                                if(!option.IsAvailable)
                                {
                                    throw new BusinessException("option không có sẵn");
                                }
                                var optionAndCount = new OptionAndCount
                                {
                                    Option = option,
                                    Count = optionCountAndIds.FirstOrDefault(x => x.Id == option.Id).Count
                                };
                                optionAndCounts.Add(optionAndCount);
                            }
                        }
                    }
                }              
            }

            if(optionCountAndIds?.Count > 0 && optionAndCounts?.Count == 0)
            {
                throw new BusinessException("danh sách có chứa optionId không tồn tại");
            }

            return new UserOrderItemAndOptionWithCountDto
            {
                ItemAndCounts = itemAndCounts,
                OptionAndCounts = optionAndCounts
            };
        }

        public async Task<UserOrderDto> GetAsync(string id)
        {
            var userOrder = await _userOrderRepository.FindAsync(id);
            if(userOrder == null)
            {
                throw new BusinessException("order không tồn tại");
            }
            return MapUserOrderToDto(userOrder);
        }

        public async Task<List<UserOrderDto>> GetByGroupOrderAsync(string groupOrderId)
        {
            var groupOrder = await _groupOrderRepository.FindAsync(groupOrderId);
            if(groupOrder == null)
            {
                throw new BusinessException("Group order không tồn tại");
            }
            var userOrders = await _userOrderRepository.GetByGroupOrderAsync(groupOrderId);
            var userOrderDtos = new List<UserOrderDto>();
            foreach(var userOrder in userOrders)
            {
                userOrderDtos.Add(MapUserOrderToDto(userOrder));
            }
            return userOrderDtos;
        }

        public async Task CreateAsync(UserOrderCreateDto input)
        {
            var restaurants = await _restaurantRepository.GetRestaurantsByNameAndIdAsync(input.RestaurantId);
            if (!restaurants.Any())
            {
                throw new BusinessException("Nhà hàng không tồn tại");
            }
            var restaurant = restaurants[0];
            var itemsAndOptionsWithCount = CheckAndGetItemsAndOptionsWithCount(restaurant, input.ItemCountAndIds, input.OptionCountAndIds);

            var user = await _identityUserRepository.FindAsync((Guid)_currentUser.Id);
            if(user == null)
            {
                throw new BusinessException("user không tồn tại");
            }
            var userOrder = new UserOrder(
                id : _guidGenerator.Create().ToString(),
                groupOrderId : input.GroupOrderId,
                user : user,
                itemAndCounts : itemsAndOptionsWithCount.ItemAndCounts,
                totalItem : input.ItemCountAndIds.Sum(x => x.Count),
                note : input.Note,
                optionAndCounts : itemsAndOptionsWithCount.OptionAndCounts,
                totalOption : input.OptionCountAndIds.Sum(x => x.Count)
                );
            
            await _userOrderRepository.InsertAsync(userOrder);
        }

        public async Task UpdateAsync(UserOrderUpdateDto input, string id)
        {
            var userOrder = await _userOrderRepository.FindAsync(id);
            if(userOrder == null)
            {
                throw new BusinessException("user order không tồn tại");
            }
            var restaurants = await _restaurantRepository.GetRestaurantsByNameAndIdAsync(input.RestaurantId);
            if (!restaurants.Any())
            {
                throw new BusinessException("Nhà hàng không tồn tại");
            }
            var restaurant = restaurants[0];
            var itemsAndOptionsWithCount = CheckAndGetItemsAndOptionsWithCount(restaurant, input.ItemCountAndIds, input.OptionCountAndIds);
            userOrder.ItemAndCounts = itemsAndOptionsWithCount.ItemAndCounts;
            userOrder.OptionAndCounts = itemsAndOptionsWithCount?.OptionAndCounts;
            userOrder.Note = input.Note;

            await _userOrderRepository.UpdateAsync(userOrder);
        }

        public async Task DeleteAsync(string id)
        {
            var userOrder = await _userOrderRepository.FindAsync(id);
            if (userOrder == null)
            {
                throw new BusinessException("user order không tồn tại");
            }
            await _userOrderRepository.DeleteAsync(userOrder);
        }

    }
}
