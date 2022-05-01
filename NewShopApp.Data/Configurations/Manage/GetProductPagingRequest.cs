
using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword;

        public List<int> CategoryIds { get; set; }
    }
}
