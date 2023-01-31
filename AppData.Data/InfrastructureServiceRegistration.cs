
using AppData.Application.Contracts.Infrastucture;
using AppData.Application.Contracts.Peristence;
using AppData.Application.Contracts.Persistence.ICobranza;
using AppData.Application.Contracts.Persistence.IPrestamo;
using AppData.Application.Models.EmailModels;
using AppData.Infrastructure.Email;
using AppData.Infrastructure.Persistence;
using AppData.Infrastructure.Repository;
using AppData.Infrastructure.Repository.RCobranza;
using AppData.Infrastructure.Repository.RPersona;
using AppData.Infrastructure.Repository.RPrestamo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            /*==========CONEXION A BD================*/
            services.AddDbContext<DataDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            /*==========REPOSITORIES================*/
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            //services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            services.AddScoped<ICobranzaRepository, CobranzaRepository>();

            /*==========SERVICES================*/
            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
