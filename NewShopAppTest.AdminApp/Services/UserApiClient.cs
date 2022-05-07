using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NewShopApp.ViewModels.System.User;
using Newtonsoft.Json;

namespace NewShopAppTest.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //multipart/form-data
            var client = _httpClientFactory.CreateClient();
            //post method
            client.BaseAddress = new Uri("https://localhost:5001");
           var reponse = await client.PostAsync("/api/users/authenticate", httpContent);
            var token = await reponse.Content.ReadAsStringAsync();
            return token;
        }
    }
}
