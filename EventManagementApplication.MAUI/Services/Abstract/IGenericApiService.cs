using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Abstract
{
    public interface IGenericApiService<T>
    {

        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);

    }
}
