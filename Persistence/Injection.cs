using Aplication.Contexts;
using Aplication.Courses;
using Aplication.Students;
using AutoMapper;
using Domain.Courses;
using Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Courses;
using Persistence.Repositories;
using Persistence.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IApplicationDbContext>(options => options.GetService<ApplicationDbContext>());

            services.AddRepository<Student, IStudentRepository, StudentRepository>();
            services.AddRepository<Course, ICourseRepository, CourseRepository>();




            return services;
        }
    }
}
