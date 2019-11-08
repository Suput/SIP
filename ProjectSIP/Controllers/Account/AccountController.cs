using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectSIP.Exceptions;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Responses.Identity;
using ProjectSIP.Services.Configure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Controllers.Account
{
    [Route("api/account")]
    public class AccountController : MainController
    {
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;
        private readonly RoleManager<Role> roleManager;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger,
            IMapper mapper, RoleManager<Role> roleManager) : base (userManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserView>> GetUserInfoAsync(int userId)
        {
            try
            {
                return Ok(mapper.Map<UserView>(await userManager.FindByIdAsync(userId.ToString())));
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message + "\n" + ex.StackTrace);
                logger.LogError("--- INNER EXCEPTION: ---\n" + ex.InnerException.Message);
                throw new CantFindUserException();
            }
        }

        [HttpGet("allusers")]
        public async Task<ActionResult<IEnumerable<UserView>>> GetAllUsers(string search = "")
        {
            return await userManager.Users
                .Where(u => u.Secondname.Contains(search) || u.Firstname.Contains(search) || u.Middlename.Contains(search))
                .ProjectTo<UserView>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("users")]
        [Authorize(Roles = RolesConstants.admin)]
        public async Task<ActionResult<IEnumerable<UserRoleView>>> GetAllUsersWithRoles()
        {
            List<UserRoleView> userRoleViews = new List<UserRoleView>();

            var users = await userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = (await userManager.GetRolesAsync(user)).ToList();
                userRoleViews.Add(new UserRoleView
                {
                    User = mapper.Map<UserView>(user),
                    Roles = roles
                });
            }
            return Ok(userRoleViews);
        }

        [HttpGet("myroles")]
        public async Task<ActionResult<IEnumerable<string>>> GetCurrentUserRoles()
            => (await userManager.GetRolesAsync(
                    await GetCurrentUser()))
                .ToList();

        [HttpGet("roles")]
        [Authorize(Roles = RolesConstants.admin)]
        public async Task<ActionResult<IEnumerable<RoleView>>> GetAllRoles()
            => await roleManager.Roles
            .ProjectTo<RoleView>(mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
