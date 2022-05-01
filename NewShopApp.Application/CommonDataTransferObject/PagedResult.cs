using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Application.CommonDataTransferObject
{
    public class PagedResult<T>
    {
        public List<T> items { get; set; }
        public int TotalRecord { get; set; }
    }
}
