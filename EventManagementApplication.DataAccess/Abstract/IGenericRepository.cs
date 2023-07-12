using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);
        T GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includeProperties);
        List<T> List(Expression<Func<T, bool>> where);
        T? Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
