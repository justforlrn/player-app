using Newtonsoft.Json;
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
        public RestaurantService(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            return restaurantData;
        }
    }
}
