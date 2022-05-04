using NewShopApp.ViewModels.Catalog.Product;
using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewShopApp.Application.Catalog.Product
{
    public interface  IPublicProductService
    {
        Task <PagedResult<ProductViewModel>> GetAllByCategoryId(string languageID, GetPublicProductPagingRequest request);
     //   Task<List<ProductViewModel>> GetAll(string languageID);
    }
}
