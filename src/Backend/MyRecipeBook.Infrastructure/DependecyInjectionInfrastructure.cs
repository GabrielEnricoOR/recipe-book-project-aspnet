using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.Security.PasswordHashing;
using System;
using System.Collections.Generic;
using System.Text;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.Repositories;

namespace MyRecipeBook.Infrastructure
{
    public static class DependecyInjectionInfrastructure
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddDbContext<MyRecipeBookDbContext>(options =>
            {
                
            });
        }

    }
}
