using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NewShopApp.ViewModels.Common;
using NewShopApp.ViewModels.System.Languages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NewShopAppTest.AdminApp.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor): base(httpClientFactory,configuration,httpContextAccessor)
        // , IConfiguration configuration)
        {
           
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVm>>> ("/api/languages");
        }
    }
}
