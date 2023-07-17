using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user);


    }
}
