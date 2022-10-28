using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OAnQuanWebAPI.Common;
using OAnQuanWebAPI.Models;
using OAnQuanWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAnQuanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName or Password Are Not Correct !");
            }
            else
            {
                return Ok(new ApiResponse
                {
                    StatusCode = "201",
                    Message = "Login Success",
                    Data = resultToken,
                });
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _userService.Register(request);
                if (!result)
                {
                    return BadRequest(new ApiResponse
                    {
                        StatusCode = "404",
                        Message = "Register is Failed !"
                    });
                }
                return Ok(new ApiResponse
                {
                    StatusCode = "201",
                    Message = "Register is Success"
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new ApiResponse
                {
                    StatusCode = "404",
                    Message = "Some thing wrong"
                });
            }
        } 
    }
}
