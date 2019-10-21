using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Options;
using System;
using System.Threading.Tasks;
using WebApp.Configure.Models.Configure.Interfaces;

namespace ProjectSIP.Services.Configure
{
    public static class RolesConstants
    {
        public const string admin = "admin";
        public const string user = "user";
    }

    public class FillDb : IConfigureWork
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<FillDb> logger;
        private readonly FillDbOptions options;

        private int tryCount = 10;
        private TimeSpan tryPeriod = TimeSpan.FromSeconds(5);

        public FillDb(IOptions<FillDbOptions> options,
            UserManager<User> userManager, RoleManager<Role> roleManager,
            ILogger<FillDb> logger)
        {
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
            if (!await userManager.IsInRoleAsync(user, RolesConstants.admin))
            {
                var adminRole = await userManager.AddToRoleAsync(user, RolesConstants.admin);
                logger.LogDebug($"Result of addting user %{user.Email}% to role %{RolesConstants.admin}% is %{adminRole}%");
            }
            else
                logger.LogInformation($"User %{user.Email}% already has role %{RolesConstants.admin}%");
            if (!await userManager.IsInRoleAsync(user, RolesConstants.user))
            {
                var userRole = await userManager.AddToRoleAsync(user, RolesConstants.user);
                logger.LogDebug($"Result of addting user %{user.Email}% to role %{RolesConstants.user}% is %{userRole}%");
            }
            else
                logger.LogInformation($"User %{user.Email}% already has role %{RolesConstants.user}%");
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
