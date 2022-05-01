using NewShopApp.Data.Entities;
using NewShopApp.Data.EntityFramework;
using NewShopApp.Ultities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using NewShopApp.ViewModels.Catalog.Product;
using NewShopApp.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using NewShopApp.Application.Common;

namespace NewShopApp.Application.Catalog.Product
{
    public class ManageProductService : IManageProductService
    {
        private readonly NewShopAppDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(NewShopAppDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount = +1;
            await _context.SaveChangesAsync();
        }


        public async Task<int> Craete(ProductCreateRequest request)
        {
            var product = new ProductTest()
            {
                Price = request.Price,
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int productId)
        {

            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new NewShopExceptions($"Can not find your searched product: {productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        //public Task<List<ProductViewModel>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.ProductId equals c.ID
                        //   where pt.Name.Contains(request.Keyword)
                        select new { p, pt, pic };
            //filter 
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //paging
            int totalRow = await query.CountAsync();

            var dataCheck = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
            // select and project 
            .Select(x => new ProductViewModel()
            {
                ID = x.p.ID,
                Name = x.pt.Name,
                DateCreated = x.p.DateCreated,
                Description = x.pt.Description,
                Details = x.pt.Details,
                LanguageID = x.pt.LanguageID,
                OriginalPrice = x.p.OriginalPrice,
                Price = x.p.Price,
                SeoDescription = x.pt.SeoDescription,
                SeoAlias = x.pt.SeoAlias,
                SeoTitle = x.pt.SeoTitle,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount

            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,

                items = dataCheck,
            };
            return pagedResult;

        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new ProductTest()
            {

                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description=request.Description,
                        Details=request.Details,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        LanguageID=request.LanguageID
                    }
                }


            };
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductInImage>()
                {
                    new ProductInImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageID == request.LanguageID);
            if (product == null || productTranslation == null) throw new NewShopExceptions($"Can not find product with Id: {request.Id}");

            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;


            //Save image
            var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
            if (thumbnailImage != null)
            {
                thumbnailImage.FileSize = request.ThumbnailImage.Length;
                thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                _context.ProductImages.Update(thumbnailImage);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new NewShopExceptions($"Can not find product with Id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new NewShopExceptions($"Can not find product with Id: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }


        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
            // "/" + USER_CONTENT_FOLDER_NAME + "/" +
        }


        public Task<int> AddImage(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
