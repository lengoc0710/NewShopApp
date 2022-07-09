using NewShopApp.ViewModels.Catalog.Product;
using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewShopAppTest.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductVm>>> GetPagings(GetManageProductPagingRequest request);
    }
}
