using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewShopApp.ViewModels.Catalog.Product
{
   public class ProductVm
    {
        [Display(Name = "ID")]
        public int ID { set; get; }
        [Display(Name = "Name")]

        public string Name { set; get; }
        [Display(Name = "Price")]
        public decimal Price { set; get; }

        [Display(Name = "OriginalPrice")]
        public decimal OriginalPrice { set; get; }
        [Display(Name = "Stock")]
        public int Stock { set; get; }
       
        public int ViewCount { set; get; }

       
        public DateTime DateCreated { set; get; }
      
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageID { set; get; }
        //public bool? IsFeatured { get; set; }

        //public string ThumbnailImage { get; set; }

        public List<string> Categories { get; set; } = new List<string>();
    }
}
