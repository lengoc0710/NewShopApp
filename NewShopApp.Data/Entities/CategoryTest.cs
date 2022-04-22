using NewShopApp.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Entities
{
    public class CategoryTest
    {
        public int ID { set; get; }
        public int SortOrder { set; get; }
        public int OnHome { set; get; }
        public int? ParentID { set; get; }
        public Status Status { set; get; }
    }
}
