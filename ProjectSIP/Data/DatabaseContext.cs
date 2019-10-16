using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectSIP.Models.Document;
using ProjectSIP.Models.Identity;

namespace ProjectSIP.Data
{
    public class DatabaseContext : IdentityDbContext<User,Role,int>
    {
        public DbSet<Document> Documents { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // my functions for configuration
            ConfigureDocument(builder);
            ConfigureFrom(builder);
            ConfigureTo(builder);
        }

        private void ConfigureTo(ModelBuilder builder)
        {
            builder.Entity<To>(opt =>
            {
                opt.HasKey(to => to.Id);
            });
        }

        private void ConfigureFrom(ModelBuilder builder)
        {
            builder.Entity<From>(opt =>
            {
                opt.HasKey(from => from.Id);
            });
        }

        private void ConfigureDocument(ModelBuilder builder)
        {
            builder.Entity<Document>(opt =>
            {
                opt.HasKey(doc => doc.Id);
            });
        }
    }
}
