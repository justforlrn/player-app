using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Player.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Player.Users
{
    [RemoteService(IsEnabled = false)]
    public class AppUserService: PlayerAppService, IAppUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityUserRepository _identityUserRepository;
        public AppUserService(
            IConfiguration configuration, 
            IHttpClientFactory httpClientFactory,
            IIdentityUserRepository identityUserRepository) {
                _configuration = configuration;
                _httpClientFactory = httpClientFactory;
                _identityUserRepository = identityUserRepository;
        }
        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            //default username same as email
            var user = await _identityUserRepository.FindByNormalizedUserNameAsync(loginDto.Email.ToUpper());
            if (user == null)
            {
                throw new UserFriendlyException("Không có tài khoản này");
            }
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

            var jsonRead = await response.Content.ReadAsStringAsync();
            var connectTokenResponse = JsonConvert.DeserializeObject<ConnectTokenResponse>(jsonRead);
            var resonse = new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Sex = user.GetProperty<string>("Sex"),
                AccessToken = connectTokenResponse.access_token
            };
            return resonse;
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

        public async Task GetUserMinimizedList()
        {

        }
    }
}
