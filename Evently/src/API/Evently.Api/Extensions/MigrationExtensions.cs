using Evently.Modules.Events.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Evently.Api.Extentions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<EventsDbContext>(scope);
    }

    private static void ApplyMigration<TdbContext>(IServiceScope scope) where TdbContext : DbContext
    {
        using TdbContext context = scope.ServiceProvider.GetRequiredService<TdbContext>();

        context.Database.Migrate();
    }
}
