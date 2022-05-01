using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.Catalog.Product
{
   public  class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword;

        public List<int> CategoryIds { get; set; }
    }
}
