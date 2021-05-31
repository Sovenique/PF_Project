using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PF_Project_CORE.Database;
using PF_Project_CORE.Entities;
using PF_Project_CORE.Interfaces;
using PF_Project_CORE.Services;

namespace PF_Project_CORE
{
    public static class DependencyInjection
    { 
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IServiceMember, ServiceMember>();
            services.AddScoped<IServiceProject, ServiceProject>();
            services.AddScoped<IServicePackage, ServicePackage>();
            services.AddScoped<IServicePayment, ServicePayment>();
            services.AddIdentity<Member, IdentityRole>()
                           .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Member, IdentityRole>>()
                           .AddEntityFrameworkStores<ApplicationDbContext>()
                           .AddDefaultTokenProviders()
                           .AddDefaultUI();

            return services;
        }

      
       
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))


            );
            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


          
            return services;
        }
    }
}
