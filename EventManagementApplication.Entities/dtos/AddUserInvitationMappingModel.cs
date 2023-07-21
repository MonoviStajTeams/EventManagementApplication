using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.dtos
{
    public class AddUserInvitationMappingModel
    {
        public int[] UserIds { get; set; }
        public int InvitationId { get; set; }
    }
}
