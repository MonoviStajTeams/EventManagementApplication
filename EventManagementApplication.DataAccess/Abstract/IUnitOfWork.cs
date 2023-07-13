using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IEventRepository Events { get; }
        IInvitationRepository Invitations { get; }
        ILocationRepository Locations { get; }
        INotificationRepository Notifications { get; }
        IRoleRepository Roles { get; }
        IUserDetailRepository UserDetails { get; }
        IUserInvitationMappingRepository UserInvitationMappings { get; }
        IUserRepository Users { get; }

        void Save();
    }
}
