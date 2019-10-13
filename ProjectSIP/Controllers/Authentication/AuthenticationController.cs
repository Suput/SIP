using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSIP.Exceptions;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Requests.Auth;
using ProjectSIP.Models.Responses.Auth;
using ProjectSIP.Models.Responses.Identity;
using ProjectSIP.Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Controllers.Authentication
{
    [Route("api/auth")]
    public class AuthenticationController : MainController
    {
        private readonly IMapper mapper;
        private readonly IJwtFactory jwtFactory;

        public AuthenticationController(UserManager<User> userManager, IMapper mapper, IJwtFactory jwtFactory)
            : base (userManager)
        {
            this.mapper = mapper;
            this.jwtFactory = jwtFactory;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            if (await userManager.Users.AnyAsync(u => u.Email == createUserRequest.Email))
                return BadRequest("Пользователь с такой почтой уже существует");

            var user = mapper.Map<User>(createUserRequest);
            user.UserName = user.Email;
            var result = await userManager.CreateAsync(user, createUserRequest.Password);
            if (result.Succeeded)
                return Ok("Вы зарегистрированы!");

            return BadRequest("Что-то пошло не так");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Email)
                ?? throw new CantFindUserException();

            if (!await userManager.CheckPasswordAsync(user, loginRequest.Password))
                return BadRequest("Неверный пароль");

            var loginResponse = GetLoginResponse(user);
            return Ok(loginResponse);
        }

        private LoginResponse GetLoginResponse(User user)
            => new LoginResponse
            {
                User = mapper.Map<UserView>(user),
                AccessToken = jwtFactory.GenerateAccessToken(user.Id)
            };
    }
}
