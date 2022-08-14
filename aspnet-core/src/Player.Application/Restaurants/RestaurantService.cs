using Newtonsoft.Json;
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
    public class RestaurantService: PlayerAppService, IRestaurantService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRestaurantRepository _restaurantRepository;
        //private readonly IItemService _itemService;
        public RestaurantService(
            IHttpClientFactory httpClientFactory, IRestaurantRepository restaurantRepository)
        {
            _httpClientFactory = httpClientFactory;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<GrabRestaurantData> GrabCrawler(string url)
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
            var listItem = new List<Item>();

            restaurantData.menu.categories.ForEach(grabCat =>
            {
                grabCat.items.ForEach(grabItem =>
                {
                    var item = new Item(
                        id: grabItem.ID,
                        name: grabItem.name,
                        imageUrl: grabItem.imgHref,
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
                            //item.Options.Add(new OptionDto(
                            //    id: child.ID,
                            //    name: child.name,
                            //    isAvailable: child.available,
                            //    price: child.priceInMinorUnit
                            //    ));
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
                    imageUrl: restaurantData.photoHref,
                    webUrl: ""
                );
            restaurantDto.Items = listItem;
            var restaurant = await CreateAsync(restaurantDto);
            return restaurantData;
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
    }
}
