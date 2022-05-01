
using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.Catalog.Product
{
  public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
       // public string Keyword;

        //public List<int> CategoryIds { get; set; }
    }
}
