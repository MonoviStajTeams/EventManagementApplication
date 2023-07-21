using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class InvitationRepository : GenericRepository<Invitation>, IInvitationRepository
    {
        private readonly EventManagementDbContext _dbContext;
        public InvitationRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetLastInvitationId()
        {
            var lastInvitationId = _dbContext.Invitations!
                .OrderByDescending(c => c.Id)
                .Select(c => c.Id)
                .FirstOrDefault();

            return lastInvitationId;
        }
    }
}
