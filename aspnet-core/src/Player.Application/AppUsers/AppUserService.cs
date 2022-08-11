using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Player.AppUsers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Player.AppUsers
{
    [RemoteService(IsEnabled = false)]
    public class AppUserService: PlayerAppService, IAppUserService
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClientFactory _httpClientFactory;
        public AppUserService(IConfiguration configuration, IHttpClientFactory httpClientFactory) {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task Login(LoginDto loginDto)
        {
            var bodyJson = JsonConvert.SerializeObject(loginDto);
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(bodyJson);
            dic.Add("clientId", _configuration.GetSection("AuthServer")["SwaggerClientId"]);
            dic.Add("clientSecret", _configuration.GetSection("AuthServer")["SwaggerClientSecret"]);
            dic.Add("scope", "");
            var client = _httpClientFactory.CreateClient();

            var data = new[]
            {
                new KeyValuePair<string, string>("client_id", _configuration.GetSection("AuthServer")["ClientId"]),
                new KeyValuePair<string, string>("client_secret", _configuration.GetSection("AuthServer")["ClientSecret"]),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", loginDto.Email),
                new KeyValuePair<string, string>("password", loginDto.Password),
            };
            var response = await client.PostAsync($"{_configuration.GetSection("AuthServer")["Authority"]}/connect/token", new FormUrlEncodedContent(data));

            var jsonResponse = await response.Content.ReadAsStringAsync();

            //if (response.IsSuccessStatusCode)
            //{
            //    result.Data = JsonConvert.DeserializeObject<Model>(jsonResponse);
            //}
            //else
            //{

            //    result.Data = JsonConvert.DeserializeObject<RemoteServiceErrorResponse>(jsonResponse);
            //}
            //return result;
        }
    }
}
