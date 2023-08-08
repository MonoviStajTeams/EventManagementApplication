using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.dtos
{
    public class InvitationUserModel
    {
        public Invitation Invitation { get; set; }
        public User User { get; set; }
    }
}
