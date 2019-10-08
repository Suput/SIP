using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectSIP.Models.Identity;

namespace ProjectSIP.Data
{
    public class DatabaseContext : IdentityDbContext<User,Role,int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // my functions for configuration
        }
    }
}
