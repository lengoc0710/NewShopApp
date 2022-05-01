using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewShopApp.Data.Entities
{
    //[Table("ProdectTest")]
    public class ProductTest
    {
        public int ID { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }

        public bool? IsFeatured { get; set; }
        //[Required]
        public string SeoAllias { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }

         public List<OrderDetail> OrderDetails { get; set; }

         public List<Cart> Carts { get; set; }

         public List<ProductTranslation> ProductTranslations { get; set; }

         public List<ProductInImage> ProductImages { get; set; }
    }
}
