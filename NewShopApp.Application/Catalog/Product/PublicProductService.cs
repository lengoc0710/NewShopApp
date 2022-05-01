using NewShopApp.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewShopApp.ViewModels.Common;
using NewShopApp.ViewModels.Catalog.Product;

namespace NewShopApp.Application.Catalog.Product
{
    public class PublicProductService : IPublicProductService
    {
        // public int productId { get; set; }
        private readonly NewShopAppDbContext _context;
        public PublicProductService(NewShopAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.ProductId equals c.ID
                        //   where pt.Name.Contains(request.Keyword)
                        select new { p, pt, pic };
            var data = await query.Select(x => new ProductViewModel()
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
            return data;

        }
  

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {

            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.ProductId equals c.ID
                        //   where pt.Name.Contains(request.Keyword)
                        select new { p, pt, pic };
            //filter 
            //if (!string.IsNullOrEmpty(request.Keyword))
            //    query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            //remove filter 
            if (request.CategoryId.HasValue && request.CategoryId.Value>0)
            {
                query = query.Where(p => p.pic.CategoryId ==  request.CategoryId);
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
    }
}
