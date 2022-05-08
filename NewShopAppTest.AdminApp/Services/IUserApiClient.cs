using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewShopApp.ViewModels.Common;
using NewShopApp.ViewModels.System.User;

namespace NewShopAppTest.AdminApp.Services
{
   public  interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVm>> GetUserPaging(GetUserPagingRequest request);
    }
}
