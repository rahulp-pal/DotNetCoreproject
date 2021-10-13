using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Infrastructure.Identity;
using ProjectName.Infrastructure.Persistence;
using ProjectName.Infrastructure.Services;
using ProjectName.Notification.Interfaces;
using ProjectName.Notification.Models;
using ProjectName.Notification.Services;

namespace ProjectName.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ProjectNameDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped(provider => (IApplicationDbContext)provider.GetService<ApplicationDbContext>());
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentityServer().AddApiAuthorization<IdentityUser, ApplicationDbContext>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddAuthentication().AddIdentityServerJwt();
            services.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddScoped<IEmailSender, EmailService>();

            return services;
        }
    }
        
}
