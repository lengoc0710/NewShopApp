
using NewShopApp.Application.Catalog.Product.DataTransferObject;
using NewShopApp.Application.Catalog.Product.DataTransferObject.Public;
using NewShopApp.Application.CommonDataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewShopApp.Application.Catalog.Product
{
    public interface  IPublicProductSerivice
    {
        Task <PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
