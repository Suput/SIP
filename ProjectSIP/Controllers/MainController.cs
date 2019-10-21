using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectSIP.Exceptions;
using ProjectSIP.Models.Identity;
using System;
using System.Threading.Tasks;

namespace ProjectSIP.Controllers
{
    [TypeFilter(typeof(CustomExceptionFilter))]
    [Produces("application/json")]
    [ApiController]
    public class MainController : ControllerBase
    {
        protected readonly UserManager<User> userManager;

        public MainController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected int GetCurrentUserId()
            => Convert.ToInt32(userManager.GetUserId(User));

        protected async Task<User> GetCurrentUser()
            => await userManager.FindByIdAsync(GetCurrentUserId().ToString()) 
            ?? throw new CantFindUserException();
    }
}
