using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.Conmon
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            IsSuccess = true;
            ResultObj = resultObj;
        }
        public ApiSuccessResult()
        {
            IsSuccess = true;
        }
    }
}
