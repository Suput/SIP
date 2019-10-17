using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectSIP.Exceptions;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Responses.Identity;
using System;
using System.Threading.Tasks;

namespace ProjectSIP.Controllers.Account
{
    [Route("api/account")]
    public class AccountController : MainController
    {
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger) : base (userManager)
        {
            this.logger = logger;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserView>> GetUserInfoAsync(int userId)
        {
            try
            {
                return Ok(await userManager.FindByIdAsync(userId.ToString()));
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message + "\n" + ex.StackTrace);
                logger.LogError("--- INNER EXCEPTION: ---\n" + ex.InnerException.Message);
                throw new CantFindUserException();
            }
        }
    }
}
