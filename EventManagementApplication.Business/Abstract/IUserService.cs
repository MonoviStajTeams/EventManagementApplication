using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        List<OperationClaim> GetClaims(User user);
        
        User GetByMail(string mail);
    }
}
