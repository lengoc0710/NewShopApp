using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewShopApp.Ultities.Constant;
using NewShopAppTest.AdminApp.Models;
using NewShopAppTest.AdminApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewShopAppTest.AdminApp.Controllers.Component
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;

        public NavigationViewComponent(ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;
        }
        //{
        //    _languageApiClient = languageApiClient;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
             var languages = await _languageApiClient.GetAll();

            //var items = languages.ResultObj.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString(),
            //    Selected = currentLanguageId == null ? x.IsDefault : currentLanguageId == x.Id.ToString()
            //});
            var navigationVm = new NavigationViewModel()
            {
                CurrentLanguageId = HttpContext
                .Session
                .GetString(SystemConstant.AppSettings.DefaultLanguageId),
                Languages = languages.ResultObj
        };

            return View("Default", navigationVm);
        }
    }
}
