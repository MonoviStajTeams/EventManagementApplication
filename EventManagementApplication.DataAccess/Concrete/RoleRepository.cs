using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(EventManagementDbContext dbContext) : base(dbContext)
        {

        }
    }
}
