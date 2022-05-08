using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.System.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
