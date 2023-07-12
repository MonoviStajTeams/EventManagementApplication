using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface IUserDetailService : IGenericService<UserDetail>
    {
        IEnumerable<UserDetail> GetAll();
        UserDetail GetById(int id);
        void Create(UserDetail entity);
        void Update(UserDetail entity);
        void Delete(int id);
    }
}
