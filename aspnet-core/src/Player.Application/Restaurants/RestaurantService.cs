using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Player.GroupOrders;
using Player.Items;
using Player.OptionGroups;
using Player.Options;
using Player.Restaurants.DTOs;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;

namespace Player.Restaurants
{
    [RemoteService(IsEnabled = false)]
    public class RestaurantService : PlayerAppService, IRestaurantService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDistributedCache<RestaurantDto> _cache;
        private readonly IConfiguration _configuration;
        public RestaurantService(
            IHttpClientFactory httpClientFactory, 
            IRestaurantRepository restaurantRepository,
            IDistributedCache<RestaurantDto> cache,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _restaurantRepository = restaurantRepository;
            _cache = cache;
            _configuration = configuration;
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
                        imageUrl: grabItem.images.Count() > 0 ? grabItem.images[0] : "",
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

        public async Task<RestaurantDto> Cache_Get(string Id)
		{
            string key = $"restaurant-{Id}";
            var restaurantDto = await _cache.GetAsync(key);
            if (restaurantDto == null)
			{
                var restaurant = await _restaurantRepository.GetByIdAsync(Id);
                if (restaurant != null)
				{
                    restaurantDto = ObjectMapper.Map<Restaurant, RestaurantDto>(restaurant);
                    await _cache.SetAsync(key, restaurantDto);
                }
            }
            return restaurantDto;
        }

        public async Task Cache_Set(RestaurantDto restaurant)
        {
            string key = $"restaurant-{restaurant.Id}";
            await _cache.SetAsync(key, restaurant);
        }

        public async Task<RestaurantDto> GrabCrawlerAsync(string url)
        {
            //kiểm tra restaurant có trong cache chưa, có rồi thì lấy ra
            var split = url.Split('/');
            var id = split[split.Count() - 1];
            var restaurant = await Cache_Get(id);
            if (restaurant != null)
			{
                return restaurant;
			}

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
            restaurant = await CreateAsync(handler);
            await Cache_Set(restaurant);
            return restaurant;
        }

        /// <summary>
        /// Content: Id, url, name
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
		public async Task<List<RestaurantDto>> GetRestaurantsAsync(string content)
		{
			var restaurant = new List<Restaurant>() { };
			if (content.ToLower().Contains(".grab"))
			{
				var splitArr = content.Split("/");
				var splitedId = splitArr[splitArr.Length - 1];
                var restaurantDb = await _restaurantRepository.GetByIdAsync(splitedId);
                var map = ObjectMapper.Map<Restaurant, RestaurantDto>(restaurantDb);
                await Cache_Set(map);
                restaurant.Add(restaurantDb);
				if (restaurant.Count() == 0)
				{
					return new List<RestaurantDto> { await GrabCrawlerAsync(content) };
				}

				return ObjectMapper.Map<List<Restaurant>, List<RestaurantDto>>(restaurant);
			}

            var t1 = await _restaurantRepository.GetListAsync();
            await _cache.SetAsync("restaurant-2", ObjectMapper.Map<Restaurant, RestaurantDto>(t1[0]));

            var redis = ConnectionMultiplexer.Connect(_configuration["Redis:Configuration"]);
                var host = _configuration["Redis:Configuration"];
                var port = _configuration["Redis:Port"];
                var server = redis.GetServer($"{host}:{port}");

			var db = redis.GetDatabase(0);

            var keyList = server.Keys(pattern: "*restaurant*").ToArray();
            var listTemp = new List<RestaurantDto>();
            var value = await db.HashGetAsync(keyList[1], "data");
            var v1 = JsonConvert.DeserializeObject<RestaurantDto>(value);
            //var y = await xx.StringGetAsync();
            //var ok = y[0].ToString();
            //var z = JsonConvert.DeserializeObject<RestaurantDto>(y[0]);
			//            foreach(var key in x)
			//{
			//                var u = await xx.StringGetAsync(key);
			//            }
			//            server.
			//            result.ForEach(async r =>
			//{

			//            });

			//}
			restaurant = await _restaurantRepository.GetRestaurantsByNameAndIdAsync(content);

			var result = ObjectMapper.Map<List<Restaurant>, List<RestaurantDto>>(restaurant);
			return result;
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
                restaurant.Items = input.Items;
                await _restaurantRepository.InsertAsync(restaurant);
            }
            return ObjectMapper.Map<Restaurant, RestaurantDto>(restaurant);
        }
    }
}
