using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public UserRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EventManagementDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    

        public User GetUserByMail(string mail)
        {
            var userMail = _dbContext.Users.Where(x => x.Mail == mail).FirstOrDefault();
            return userMail!;
        }


 }
}
