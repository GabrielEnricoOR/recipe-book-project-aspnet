using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.Security.PasswordHashing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Infrastructure
{
    public static class DependecyInjectionInfrastructure
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHashing, Argon2PasswordHasher>();
        }

    }
}
