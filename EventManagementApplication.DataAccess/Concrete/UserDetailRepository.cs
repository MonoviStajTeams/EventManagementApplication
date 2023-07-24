using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class UserDetailRepository : GenericRepository<UserDetail>, IUserDetailRepository
    {
        private readonly EventManagementDbContext _dbContext;
        public UserDetailRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDetail GetUserDetailByUserId(int userId)
        {
            return _dbContext.UserDetails.FirstOrDefault(u => u.UserId == userId);
        }
    }
}

