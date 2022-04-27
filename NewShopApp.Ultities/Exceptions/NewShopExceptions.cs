using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Ultities.Exceptions
{
  public  class NewShopExceptions : Exception
    {
        public NewShopExceptions()
        {

        }
        public NewShopExceptions(string message)
        {

        }
        public NewShopExceptions(string message,Exception inner)
            :base(message,inner)
        {

        }
    }
}
