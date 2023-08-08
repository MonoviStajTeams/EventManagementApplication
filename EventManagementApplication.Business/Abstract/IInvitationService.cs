using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface IInvitationService : IGenericService<Invitation>
    {
        int GetLastInvitationId();
        IEnumerable<User> GetUsers();
        IEnumerable<Invitation> GetInvitationsByUserId(int id);
        void SendInvitationMail(int invitationId);
    }
}
