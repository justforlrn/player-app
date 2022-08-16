using Player.Options;
using Player.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Users;

namespace Player.UserOrders
{
    [RemoteService(IsEnabled = false)]
    public class UserOrderService : PlayerAppService, IUserOrderService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICurrentUser _currentUser;
        public UserOrderService(
            IRestaurantRepository restaurantRepository,
            ICurrentUser currentUser
            )
        {
            _restaurantRepository = restaurantRepository;
            _currentUser = currentUser;
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
            var itemIdsNotExist = input.ItemIds.Except(itemIdsByRestaurant).ToList();
            if(itemIdsNotExist.Count != 0)
            {
                throw new BusinessException("Danh sách có chứa món ăn không tồn tại");
            }
            var itemBooks = restaurant.Items.Where(x => input.ItemIds.Contains(x.Id)).ToList();
            foreach(var itemBook in itemBooks)
            {
                itemBook.OptionGroups = null;
                foreach(var optionGroup in itemBook.OptionGroups)
                {
                    optionGroup.Options = null;
                    var options = optionGroup.Options.Where(x => input.OptionIds.Contains(x.Id)).ToList();
                    if(options.Count != 0)
                    {
                        itemBook.OptionGroups.Add(optionGroup);
                        optionGroup.Options.AddRange(options);
                    }
                }
            }
            var userOrder = new UserOder(
                groupOrderId : input.GroupOrderId,
                user : _currentUser,
                items : itemBooks,

                );
            

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
