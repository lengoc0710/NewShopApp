using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Entities
{
   public class ProductInCategory
    {

        public int ProductId { get; set; }

        public ProductTest Product { get; set; }

        public int CategoryId { get; set; }

        public CategoryTest Category { get; set; }
    }
}
