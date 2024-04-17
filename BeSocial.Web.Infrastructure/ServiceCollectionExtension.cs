using System.Reflection;

using BeSocial.Data;
using BeSocial.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeSocial.Web.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection service, Type serviceType)
        {
            Assembly? assembly = Assembly.GetAssembly(serviceType);

            if (assembly == null)
            {
                throw new InvalidOperationException("Invalid Service type!");
            }

            Type[] implemationTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (var currentType in implemationTypes)
            {
                Type? interfaceType = currentType.GetInterface($"I{currentType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface with {currentType.Name} name");
                }

                service.AddScoped(interfaceType, currentType);
            }
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<BeSocialDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }


        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BeSocialDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.AllowedForNewUsers = false;
            });

            return services;
        }
    }
}
