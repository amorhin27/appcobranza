using AppData.Application.Contracts.Identity;
using AppData.Application.Models.EdentityModel;
using AppData.Identity.Models;
using AppData.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppData.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentitySrvices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<SecurityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SecurityConnectionString"),
            b => b.MigrationsAssembly(typeof(SecurityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SecurityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            //services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:key"]))
                };
            });
            return services;
        }
    }
}
