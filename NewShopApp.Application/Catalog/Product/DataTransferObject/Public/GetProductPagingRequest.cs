using NewShopApp.Application.CommonDataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Application.Catalog.Product.DataTransferObject.Public
{
  public class GetProductPagingRequest : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
