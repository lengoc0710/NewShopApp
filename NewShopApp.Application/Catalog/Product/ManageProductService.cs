using NewShopApp.Application.Catalog.Product.DataTransferObject;
using NewShopApp.Application.Catalog.Product.DataTransferObject.Manage;
using NewShopApp.Application.CommonDataTransferObject;
using NewShopApp.Data.Entities;
using NewShopApp.Data.EntityFramework;
using NewShopApp.Ultities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewShopApp.Application.Catalog.Product
{
    public class ManageProductService : IManageProductService
    {
        private readonly NewShopAppDbContext _context;
        public ManageProductService(NewShopAppDbContext context)
        {
            _context = context;
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

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
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
            if(request.CategoryIds.Count>0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //paging
            int totalRow = await query.CountAsync();

            var dataCheck = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
            // select and project 
            .Select(x => new ProductViewModel() {
                ID = x.p.ID,
                Name = x.pt.Name,
                DateCreated=x.p.DateCreated,
                Description=x.pt.Description,
                Details=x.pt.Details,
                LanguageID=x.pt.LanguageID,
                OriginalPrice=x.p.OriginalPrice,
                Price=x.p.Price,
                SeoDescription=x.pt.SeoDescription,
                SeoAlias=x.pt.SeoAlias,
                SeoTitle=x.pt.SeoTitle,
                Stock=x.p.Stock,
                ViewCount=x.p.ViewCount

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
                ViewCount=0,
                DateCreated=DateTime.Now,
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
            _context.Products.Add(product);
          return  await _context.SaveChangesAsync();

        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageID == request.LanguageID);
            if (product == null || productTranslation==null) throw new NewShopExceptions($"Can not find product with Id: {request.Id}");

            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product==null) throw new NewShopExceptions($"Can not find product with Id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new NewShopExceptions($"Can not find product with Id: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
