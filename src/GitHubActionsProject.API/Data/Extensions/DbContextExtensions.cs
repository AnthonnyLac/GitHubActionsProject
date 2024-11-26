using GitHubActionsProject.API.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GitHubActionsProject.API.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static void ApplyPendingMigrations(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Verifica se há migrações pendentes e aplica se necessário
                var pendingMigrations = dbContext.Database.GetPendingMigrations();

                if (pendingMigrations.Any())
                {
                    Console.WriteLine("Aplicando migrações pendentes...");
                    dbContext.Database.Migrate();
                }
                else
                {
                    Console.WriteLine("Não há migrações pendentes.");
                }
            }
        }

      
    }
}
