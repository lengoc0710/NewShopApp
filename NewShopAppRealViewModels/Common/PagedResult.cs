using NewShopApp.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> items { get; set; }
        //public int TotalRecords { get; set; }
    }
}
