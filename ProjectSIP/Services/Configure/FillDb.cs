using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectSIP.Data;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Configure.Models.Configure.Interfaces;

namespace ProjectSIP.Services.Configure
{
    public static class RolesConstants
    {
        public static string admin = "admin";
        public static string user = "user";
    }

    public class FillDb : IConfigureWork
    {
        private readonly DatabaseContext context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<FillDb> logger;
        private readonly FillDbOptions options;

        private int tryCount = 10;
        private TimeSpan tryPeriod = TimeSpan.FromSeconds(5);

        public FillDb(DatabaseContext context, IOptions<FillDbOptions> options,
            UserManager<User> userManager, RoleManager<Role> roleManager,
            ILogger<FillDb> logger)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
            this.options = options.Value;
        }

        public async Task Configure()
        {
            try
            {
                await AddDefaultUser();
                await AddRoles();
                await AddRoleToDefaultUser();
            }
            catch (Exception ex)
            {
                if (tryCount == 0)
                    throw;

                logger.LogWarning(ex, "Error while filling Database by default data");
                tryCount--;
                await Task.Delay(tryPeriod);
                await Configure();
            }
        }

        private async Task AddRoleToDefaultUser()
        {
            if (!await userManager.Users.AnyAsync()
                || !await roleManager.Roles.AnyAsync())
            {
                logger.LogCritical("No users and roles");
                return;
            }

            var user = await userManager.FindByEmailAsync(options.Email);
            if ((await userManager.GetRolesAsync(user)).Count != 0)
            {
                logger.LogInformation("Default user has some roles");
                return;
            }

            var result = await userManager.AddToRoleAsync(user, RolesConstants.admin);
            logger.LogDebug($"Result of addting user %{user.Email}% to role %{RolesConstants.admin}% is %{result}%");
        }

        private async Task AddRoles()
        {
            if (await roleManager.Roles.AnyAsync(r => r.Name == RolesConstants.admin)
                || await roleManager.Roles.AnyAsync(r => r.Name == RolesConstants.user))
            {
                logger.LogInformation("Some default roles are already exist");
                return;
            }

            var admin = await roleManager.CreateAsync(
                new Role
                {
                    Name = RolesConstants.admin
                });
            var user = await roleManager.CreateAsync(
                new Role
                {
                    Name = RolesConstants.user
                });
            logger.LogDebug($"Result of creating roles: %{RolesConstants.admin}% - %{admin}%, %{RolesConstants.user}% - %{user}%");
        }

        private async Task AddDefaultUser()
        {
            if (await userManager.Users.AnyAsync(u => u.Email == options.Email))
            {
                logger.LogInformation("Default user exists");
                return;
            }

            var result = await userManager.CreateAsync(new User
            {
                Firstname = options.Firstname,
                Secondname = options.Secondname,
                Middlename = options.Middlename,
                Age = options.Age,
                UserName = options.Email,
                Position = options.Position
            }, options.Password);
            logger.LogDebug($"Result of creating default user %{options.Email}% is %{result}%");
        }
    }
}
