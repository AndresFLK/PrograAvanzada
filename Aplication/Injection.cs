using Aplication.Identity;
using Aplication.Students;
using AutoMapper;
using Domain.Students;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public static class Injection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(StudentProfile));
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateStudentValidator).Assembly });

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IIdentityService, IdentityService>();

            
            return services;
        }
    }
}
