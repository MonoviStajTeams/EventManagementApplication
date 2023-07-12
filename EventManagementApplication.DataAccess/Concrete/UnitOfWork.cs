using EventManagementApplication.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        EventManagementDbContext _dbContext;

        public UnitOfWork(EventManagementDbContext dbContext)
        {

            _dbContext = dbContext;
            Events = new EventRepository(_dbContext);
            Invitations = new InvitationRepository(_dbContext);
            Locations = new LocationRepository(_dbContext);
            Roles = new RoleRepository(_dbContext);
            UserInvatationMappings = new UserInvitationMappingRepository(_dbContext);
            UserDetails = new UserDetailRepository(_dbContext);
            Users = new UserRepository(_dbContext);



        }

        public IEventRepository Events { get; }

        public IInvitationRepository Invitations { get; }

        public ILocationRepository Locations { get; }

        public INotificationRepository Notifications { get; }

        public IRoleRepository Roles { get; }

        public IUserDetailRepository UserDetails { get; }

        public IUserInvitationMappingRepository UserInvatationMappings { get; }

        public IUserRepository Users { get; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
