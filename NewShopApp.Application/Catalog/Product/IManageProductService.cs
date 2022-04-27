using NewShopApp.Application.Catalog.Product.DataTransferObject;
using NewShopApp.Application.Catalog.Product.DataTransferObject.Manage;
using NewShopApp.Application.CommonDataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewShopApp.Application.Catalog.Product
{
   public interface IManageProductService
    {
        Task<int> Craete(ProductCreateRequest request);

        //return Decoder of code for product
        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice (int productId, decimal newPrice );
        Task<bool> UpdateStock(int productId, int addedQuantity );

        Task AddViewCount(int productId);


     //   Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

    }
}
