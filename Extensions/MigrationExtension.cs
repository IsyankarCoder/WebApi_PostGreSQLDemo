using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using WebApi_PostGreSQLDemo.Database;

namespace WebApi_PostGreSQLDemo.Extensions
{
    public static class MigrationExtension
    {

        public static void ApplyMigration(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            using AppDbContext appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            appDbContext.Database.Migrate();
        }
    }
}
