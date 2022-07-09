using Microsoft.AspNetCore.Http;
using NewShopApp.ViewModels.Catalog.Product;
using NewShopApp.ViewModels.Catalog.ProductImages;
using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewShopApp.Application.Catalog.Product
{
   public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        //return Decoder of code for product
        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);
        Task<ProductVm> GetById(int productId, string languageID);

        Task<bool> UpdatePrice (int productId, decimal newPrice );
        Task<bool> UpdateStock(int productId, int addedQuantity );

        Task AddViewCount(int productId);


     //   Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request );

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage( int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageID, GetPublicProductPagingRequest request);
        //   Task<List<ProductViewModel>> GetAll(string languageID);
    

}
}
