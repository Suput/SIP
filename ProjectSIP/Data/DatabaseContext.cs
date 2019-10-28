using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectSIP.Models.Documents;
using ProjectSIP.Models.Identity;

namespace ProjectSIP.Data
{
    public class DatabaseContext : IdentityDbContext<User,Role,int>
    {
        public DbSet<EventDocument> EventDocuments { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // my functions for configuration
            ConfigureEventDocument(builder);
            ConfigureUserEventDocument(builder);
        }

        private void ConfigureUserEventDocument(ModelBuilder builder)
        {
            builder.Entity<UserEventDocument>(cfg =>
            {
                cfg.HasKey(ued => new { ued.EventDocumentId, ued.UserId });
            });
        }

        private void ConfigureEventDocument(ModelBuilder builder)
        {
            builder.Entity<EventDocument>(cfg =>
            {
                cfg.HasKey(ed => ed.Id);

                cfg.HasOne(ed => ed.MainAccountant)
                    .WithMany(u => u.EventMainAccounts)
                    .HasForeignKey(ed => ed.MainAccountantId);

                cfg.HasOne(ed => ed.Supervisor)
                    .WithMany(u => u.EventSupervisors)
                    .HasForeignKey(ed => ed.SupervisorId);

                cfg.HasOne(ed => ed.Organizator)
                    .WithMany(u => u.EventOrganizators)
                    .HasForeignKey(ed => ed.OrganizatorId);
            });
        }
    }
}
