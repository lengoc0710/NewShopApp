
using Microsoft.AspNetCore.Http;
using NewShopApp.ViewModels.Catalog.Product;
using NewShopApp.ViewModels.Common;
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
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, List<IFormFile> files );

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> GetListImages(int productId);

    }
}
