using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface IGenericService<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();

        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
