using EventManagementApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.Concrete
{
    public class UserInvitationMapping: BaseEntity
    {
        public int InvitedId { get; set; }
        public User User { get; set; }

        public bool Status { get; set; }
        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }
    }
}
