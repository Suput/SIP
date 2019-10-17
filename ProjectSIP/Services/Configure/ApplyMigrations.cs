using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectSIP.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Configure.Models.Configure.Interfaces;

namespace ProjectSIP.Services.Configure
{
    public class ApplyMigrations : IConfigureWork
    {
        private readonly DatabaseContext dbContext;
        private readonly ILogger<ApplyMigrations> logger;
        private int tryCount = 10;
        private TimeSpan tryPeriod = TimeSpan.FromSeconds(5);

        public ApplyMigrations(DatabaseContext dbContext, ILogger<ApplyMigrations> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task Configure()
        {
            try
            {
                var pending = await dbContext.Database.GetPendingMigrationsAsync();
                if (pending?.Count() != 0)
                    await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                if (tryCount == 0)
                    throw;

                logger.LogWarning(ex, "Error while appling migrations");
                tryCount--;
                await Task.Delay(tryPeriod);
                await Configure();
            }
        }
    }
}
