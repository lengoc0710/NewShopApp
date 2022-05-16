using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewShopApp.Application.System.User;
using NewShopApp.ViewModels.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewShopApp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userService.Authencate(request);

            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken);
            }
     
            return Ok (resultToken);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok();
            //result
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Update(id,request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
            //result
        }
        [HttpGet("paging")]
        //another URL
        public async Task<ActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request) //parameter specific
        {
            var products = await _userService.GetUserPaging(request);
            return Ok(products);
        }
        [HttpGet("{id}")]
        //another URL
        public async Task<ActionResult> GetById(Guid id) //parameter specific
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        //another URL
        public async Task<ActionResult> Delete(Guid id) //parameter specific
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }

    }
}
