using BilgeKitap.Business.Abstract;
using BilgeKitap.Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeKitap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _account;

        public AccountController(IAccountService account)
        {

            _account = account;
        }
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _account.UserExists(userForRegisterDto.Email);
            if (!userExists.Success) return BadRequest(userExists.Message);

            var registerResult = _account.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _account.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                //result.Message = registerResult.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _account.Login(userForLoginDto);
            if (!userToLogin.Success) return BadRequest(userToLogin.Message);

            var result = _account.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                //result.Message = userToLogin.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
