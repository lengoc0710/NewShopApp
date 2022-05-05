using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewShopApp.Application.Catalog.Product;
using NewShopApp.ViewModels.Catalog.Product;
using NewShopApp.ViewModels.Catalog.ProductImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewShopApp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet("{productId}/{LanguageID}")]
        public async Task<IActionResult> GetById(int productId, string languageID)
        {
            var product = await _manageProductService.GetById(productId, languageID);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        [HttpGet("Public-paging/{languageID}")]
        //another URL
        public async Task<ActionResult> GetALllPaging(string languageID, [FromQuery] GetPublicProductPagingRequest request) //parameter specific
        {
            var products = await _publicProductService.GetAllByCategoryId(languageID, request);
            return Ok(products);
        }
        //[HttpGet("Public-paging/{languageID}")]
        ////another URL
        //public async Task<ActionResult> GetALllPaging(string languageID, [FromQuery] GetPublicProductPagingRequest request) //parameter specific
        //{
        //    var products = await _publicProductService.GetAllByCategoryId(languageID, request);
        //    return Ok(products);
        //}
        [HttpPost]
        //new post

        public async Task<ActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _manageProductService.GetById(productId, request.LanguageID);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }
        [HttpPut]
        //new post

        public async Task<ActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var changedResult = await _manageProductService.Update(request);
            if (changedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{productId}")]

        public async Task<ActionResult> Delete(int productId)
        {
            var changedResult = await _manageProductService.Delete(productId);
            if (changedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPatch("{ productId}/{newPrice}")]


        public async Task<ActionResult> UpdatePrice([FromQuery] int productId, decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(productId, newPrice);
            if (isSuccessful)
                return Ok();
            return BadRequest();
        }
        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var imageId = await _manageProductService.AddImage(productId, request);
                if (imageId == 0)
                    return BadRequest();

                var image = await _manageProductService.GetImageById(imageId);

                return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
            
        }
        [HttpPut("{productId}/images/{imageId}")]
      //  [Authorize]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
            //200
        }

        [HttpDelete("{productId}/images/{imageId}")]
       // [Authorize]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _manageProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }
    }
}
