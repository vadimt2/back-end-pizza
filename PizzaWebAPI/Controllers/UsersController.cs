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

        private readonly IUserService _userService;

        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;


        public UsersController(IAuthService authService, ITokenService tokenService, IMapper mapper, IUserService userService)
        {
            _authService = authService;

            _userService = userService;

            _tokenService = tokenService;

            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _userService.Get());
        }



        [TypeFilter(typeof(ActionModifyFilter))]
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            IActionResult response = BadRequest("Email or password is incorrect");
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
                return BadRequest("User already exist");
            else
                return Ok(user);
        }


        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getUser = await _userService.Get(id);

            if (getUser == null)
                return NotFound("Not Found");

            return Ok(getUser);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {

            try
            {
                var getUser = await _userService.Update(id, user);

                if (getUser == null)
                    return NotFound("Not Found");

                return Ok(getUser);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _userService.Delete(id);
                if (item == 0)
                    return NotFound("Not Found");

                return Ok("User deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}