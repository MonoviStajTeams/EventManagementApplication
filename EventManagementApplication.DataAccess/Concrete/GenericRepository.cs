using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EventManagementDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }


        public T? Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;


            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public T GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(x => x.Id == id)!;
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }


        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}