using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication;
using Aplication.Identity;
using Infrastructure.Identity;

namespace Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => 
                    {
                        options.Password.RequiredLength = 6;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireUppercase = true;
                        options.Password.RequireDigit = true;
                        options.Password.RequireNonAlphanumeric = true;
                    }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();


            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
