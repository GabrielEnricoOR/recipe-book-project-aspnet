using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Infrastructure.DataAccess;

namespace MyRecipeBook.Infrastructure.Migrations;

public class DatabaseMigration
{
    public static void ExecuteMigration(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        
        runner.ListMigrations();
        runner.MigrateUp();
    }
}