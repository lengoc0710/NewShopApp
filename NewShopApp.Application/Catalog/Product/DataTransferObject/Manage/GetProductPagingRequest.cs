using NewShopApp.Application.CommonDataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Application.Catalog.Product.DataTransferObject.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword;

        public List<int> CategoryIds { get; set; }
    }
}
