using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //test yaparken token oluşturmak istersek kullanabilirz
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
