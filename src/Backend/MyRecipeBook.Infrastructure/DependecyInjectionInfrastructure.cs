using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.Security.PasswordHashing;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.Repositories;

namespace MyRecipeBook.Infrastructure
{
    public static class DependecyInjectionInfrastructure
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<MyRecipeBookDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options.AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection"))
                .ScanIn(Assembly.Load("MyRecipeBook.Infrastructure"))
                .For.All();
            });
        }

    }
}
