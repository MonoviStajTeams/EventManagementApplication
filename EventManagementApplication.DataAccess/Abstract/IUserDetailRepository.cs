using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Abstract
{
    public interface IUserDetailRepository : IGenericRepository<UserDetail>
    {
        UserDetail GetUserDetailByUserId(int userId);
    }
}
