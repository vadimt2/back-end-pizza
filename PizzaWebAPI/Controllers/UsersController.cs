using AutoMapper;
using Common;
using Common.DTO;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PizzaWebAPI.ActionFilters;

namespace PizzaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;


        public UsersController(IAuthService authService, ITokenService tokenService, IMapper mapper)
        {
            _authService = authService;

            _tokenService = tokenService;

            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content("test");
        }



        [TypeFilter(typeof(ActionModifyFilter))]
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            User user = await _authService.AuthenticateUser(login.Email, login.Password);

            var userDTO = _mapper.Map<UserDTO>(user);

            if (user != null)
            {
                var tokenString = _tokenService.GenerateJWTToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = userDTO,
                });
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User register)
        {
            var user = await _authService.Register(register);

            if (user == null)
                return BadRequest();
            else
                return Ok(user);
        }
    }
}