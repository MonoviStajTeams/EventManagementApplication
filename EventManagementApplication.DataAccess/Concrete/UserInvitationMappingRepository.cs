using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class UserInvitationMappingRepository : GenericRepository<UserInvitationMapping>, IUserInvitationMappingRepository
    {
        private readonly EventManagementDbContext _dbContext;
        public UserInvitationMappingRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserInvitationMapping> GetByUserId(int id)
        {
            return _dbContext.UserInvitationMappings.Where(x => x.InvitedId == id).ToList();
        }
    }
}
