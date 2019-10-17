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

                opt.HasOne(to => to.User)
                    .WithMany(u => u.Tos)
                    .HasForeignKey(to => to.UserId);
            });
        }

        private void ConfigureFrom(ModelBuilder builder)
        {
            builder.Entity<From>(opt =>
            {
                opt.HasKey(from => from.Id);

                opt.HasOne(from => from.User)
                    .WithMany(u => u.Froms)
                    .HasForeignKey(from => from.UserId);
            });
        }

        private void ConfigureDocument(ModelBuilder builder)
        {
            builder.Entity<Document>(opt =>
            {
                opt.HasKey(doc => doc.Id);

                opt.HasOne(doc => doc.From)
                    .WithMany(from => from.Documents)
                    .HasForeignKey(doc => doc.FromId);

                opt.HasOne(doc => doc.To)
                    .WithMany(to => to.Documents)
                    .HasForeignKey(doc => doc.ToId);
            });
        }
    }
}
