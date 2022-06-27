using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NewShopApp.Ultities.Constant;
using NewShopApp.ViewModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NewShopAppTest.AdminApp.Services
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        protected BaseApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        // , IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            //post method
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var reponse = await client.GetAsync(url);
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                TResponse myDeserializedOBjList = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return myDeserializedOBjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
    }
}
