using Player.Restaurants;
using Player.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Player.UserOrders
{
    [RemoteService(IsEnabled = false)]
    public class UserOrderService : PlayerAppService, IUserOrderService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IIdentityUserRepository _appUserRepository;
        private readonly IUserOderRepository _userOrderRepository;

        public UserOrderService(
            IRestaurantRepository restaurantRepository,
            ICurrentUser currentUser,
            IIdentityUserRepository appUserRepository,
            IUserOderRepository userOrderRepository
            )
        {
            _restaurantRepository = restaurantRepository;
            _currentUser = currentUser;
            _appUserRepository = appUserRepository;
            _userOrderRepository = userOrderRepository;
        }
        public async Task CreateAsync(UserOrderCreateDto input)
        {
            var restaurants = await _restaurantRepository.GetRestaurantsByNameAndIdAsync(input.RestaurantId);
            if (!restaurants.Any())
            {
                throw new BusinessException("Nhà hàng không tồn tại");
            }
            var restaurant = restaurants[0];
            
            var itemIdsByRestaurant = restaurant.Items.Select(x => x.Id).ToList();
            var itemIdInput = input.ItemCountAndIds.Select(x => x.Id).ToList();
            var itemIdsNotExist = itemIdInput.Except(itemIdsByRestaurant).ToList();
            if(itemIdsNotExist.Count != 0)
            {
                throw new BusinessException("Danh sách có chứa món ăn không tồn tại");
            }
            var itemBooks = restaurant.Items.Where(x => itemIdInput.Contains(x.Id)).ToList();

            var itemAndCounts = new List<ItemAndCount>();
            var optionAndCounts = new List<OptionAndCount>();

            var optionIds = input.OptionCountAndIds.Select(x => x.Id).ToList();
            foreach (var itemBook in itemBooks)
            {
                var itemAndCount = new ItemAndCount
                {
                    Item = itemBook,
                    Count = input.ItemCountAndIds.FirstOrDefault(x => x.Id == itemBook.Id).Count
                };
                itemAndCount.Item.OptionGroups = null;

                itemAndCounts.Add(itemAndCount);

                foreach(var optionGroup in itemBook.OptionGroups)
                {
                    var options = optionGroup.Options.Where(x => optionIds.Contains(x.Id)).ToList();
                    foreach(var option in options)
                    {
                        var optionAndCount = new OptionAndCount
                        {
                            Option = option,
                            Count = input.OptionCountAndIds.FirstOrDefault(x => x.Id == option.Id).Count
                        };
                        optionAndCounts.Add(optionAndCount);
                    }
                }
            }
            var user = await _appUserRepository.FindAsync((Guid)_currentUser.Id);
            var userOrder = new UserOder(
                groupOrderId : input.GroupOrderId,
                user : user,
                itemAndCounts : itemAndCounts,
                totalItem : input.ItemCountAndIds.Sum(x => x.Count),
                note : input.Note,
                optionAndCounts : optionAndCounts,
                totalOption : input.OptionCountAndIds.Sum(x => x.Count)
                );
            
            await _userOrderRepository.InsertAsync(userOrder);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserOrderDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserOrderDto>> GetByGroupOrder(string groupOrderId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserOrderUpdateDto input)
        {
            throw new NotImplementedException();
        }
    }
}
