using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Application.Catalog.Product.DataTransferObject
{
   public  class ProductViewModel
    {
        public int ID { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }

        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageID { set; get; }
    }
}
