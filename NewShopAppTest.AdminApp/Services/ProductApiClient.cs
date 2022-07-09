using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NewShopApp.ViewModels.Catalog.Product;
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
    public class ProductApiClient : IProductApiClient
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        // , IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<PagedResult<ProductVm>>> GetPagings(GetManageProductPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            //post method
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var reponse = await client.
                GetAsync($"/api/products/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}" +
                $"&keyword={ request.Keyword} &languageId ={ request.LanguageId}");

            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                PagedResult<ProductVm> myDeserializedOBjList = (PagedResult<ProductVm>)JsonConvert.DeserializeObject(body, typeof(PagedResult<ProductVm>));
                return new ApiSuccessResult<PagedResult<ProductVm>>(myDeserializedOBjList);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<ProductVm>>>(body);

        }
    }
}