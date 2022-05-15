﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.Conmon
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            IsSuccess = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccess = false;
            ValidationErrors = validationErrors;
        }
    }
}
