using Aplication.Contexts;
using Aplication.Repositories;
using Domain;
using Domain.Students;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }


        public List<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }



            return query.ToList();
        }


        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            query = query.Where(predicate);


            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
