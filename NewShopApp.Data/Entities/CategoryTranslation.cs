using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Entities
{
   public  class CategoryTranslation
    {
        public int Id { set; get; }
        public int CategoryId { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageID { set; get; }
        public string SeoAlias { set; get; }

        public CategoryTest Category { get; set; }

        public Language Language { get; set; }
    }
}
