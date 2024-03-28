using Aplication.Repositories;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository<TEntity, TContract, TRepository>
            (this IServiceCollection services)
            where TEntity : Entity
            where TContract : class, IRepositoryBase<TEntity>
            where TRepository : class, TContract
        {
            services.AddScoped<TContract, TRepository>();
            return services;
        }
    }
}
