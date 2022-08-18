using Newtonsoft.Json;
using Player.GroupOrders;
using Player.Items;
using Player.OptionGroups;
using Player.Options;
using Player.Restaurants.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Player.Restaurants
{
    [RemoteService(IsEnabled = false)]
    public class RestaurantService : PlayerAppService, IRestaurantService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IGroupOrderService _groupOrderService;
        public RestaurantService(
            IHttpClientFactory httpClientFactory, IRestaurantRepository restaurantRepository, IGroupOrderService groupOrderService)
        {
            _httpClientFactory = httpClientFactory;
            _restaurantRepository = restaurantRepository;
            _groupOrderService = groupOrderService;
        }

        public RestaurantDto GrabDataHandler(GrabRestaurantData restaurantData)
        {
            var listItem = new List<Item>();

            restaurantData.menu.categories.ForEach(grabCat =>
            {
                grabCat.items.ForEach(grabItem =>
                {
                    var item = new Item(
                        id: grabItem.ID,
                        name: grabItem.name,
                        imageUrl: grabItem.images[0],
                        priceOrigin: grabItem.priceInMinorUnit,
                        priceDiscount: grabItem.discountedPriceInMin
                        );
                    item.OptionGroups = new List<OptionGroup>();
                    grabItem.modifierGroups.ForEach(childGroup =>
                    {
                        var item_ = new OptionGroup(
                        id: childGroup.ID,
                        name: childGroup.name,
                        isAvailable: childGroup.available,
                        selectMin: childGroup.selectionRangeMin,
                        selectMax: childGroup.selectionRangeMax
                        );
                        item_.Options = new List<Option>();
                        childGroup.modifiers.ForEach(childGrab =>
                        {
                            var child = new Option(
                                id: childGrab.ID,
                                name: childGrab.name,
                                isAvailable: childGrab.available,
                                price: childGrab.priceInMinorUnit);
                            item_.Options.Add(child);
                        });
                        item.OptionGroups.Add(item_);
                    });
                    listItem.Add(item);
                });
            });

            var restaurantDto = new RestaurantDto(
                    id: restaurantData.ID,
                    name: restaurantData.name,
                    star: 0,
                    open: restaurantData.openingHours.displayedHours,
                    close: restaurantData.openingHours.displayedHours,
                    imageUrl: restaurantData.menu.categories[0].items[0].images[0],
                    webUrl: ""
                );
            restaurantDto.Items = listItem;
            return restaurantDto;
        }

        public async Task<RestaurantDto> GrabCrawlerAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 5.1; rv:5.0) Gecko/20100101 Firefox/5.0");
            HttpStatusCode statusCode = HttpStatusCode.NoContent;
            string content = "";
            while (statusCode != HttpStatusCode.OK)
            {
                var get = await client.GetAsync(url);
                statusCode = get.StatusCode;
                content = await get.Content.ReadAsStringAsync();
            }
            var stringContent = content.Split("NEXT_DATA__\" type=\"application/json\">")[1].Split("</script>")[0];
            var parseContent = JsonConvert.DeserializeObject<GrabData>(stringContent);
            var entity = parseContent.props.initialReduxState.pageRestaurantDetail.entities;
            var restaurantData = (((Newtonsoft.Json.Linq.JContainer)(((Newtonsoft.Json.Linq.JContainer)entity).First as object)).First).ToObject<GrabRestaurantData>();
            var handler = GrabDataHandler(restaurantData);
            var restaurant = await CreateAsync(handler);
            return restaurant;
            //var GO = new CreateGroupOrderDto(groupId, restaurant.Id);
            //var res = await _groupOrderService.CreateOrderGroupAsync(GO);
            //return res;
        }

        public async Task<List<RestaurantDto>> GetRestaurantsByNameAsync(string content)
        {
            var restaurant = new List<Restaurant>() { };
            if (content.ToLower().Contains(".grab"))
            {
                var splitArr = content.Split("/");
                var splitedId = splitArr[splitArr.Length-1];
                restaurant = await _restaurantRepository.GetRestaurantsByNameAndIdAsync(splitedId);
                if(restaurant.Count() == 0)
                {
                    return new List<RestaurantDto> { await GrabCrawlerAsync(content) };
                }
                return ObjectMapper.Map<List<Restaurant>, List<RestaurantDto>>(restaurant);
            }
            restaurant = await _restaurantRepository.GetRestaurantsByNameAndIdAsync(content);
            return ObjectMapper.Map<List<Restaurant>, List<RestaurantDto>>(restaurant);
        }

        public async Task<RestaurantDto> CreateAsync(RestaurantDto input)
        {
            var restaurant = await _restaurantRepository.FindAsync(input.Id);
            if (restaurant == null)
            {
                restaurant = new Restaurant(
                    id: input.Id,
                    name: input.Name,
                    star: input.Star,
                    open: input.Open,
                    close: input.Close,
                    imageUrl: input.ImageUrl,
                    webUrl: input.WebUrl);
                var items = ObjectMapper.Map<List<Item>, List<Item>>(input.Items);
                restaurant.Items = items;
                await _restaurantRepository.InsertAsync(restaurant);
            }
            return ObjectMapper.Map<Restaurant, RestaurantDto>(restaurant);
        }

        public Task<RestaurantDto> GrabCrawlerAsync(string url)
        {
            throw new NotImplementedException();
        }
    }
}
