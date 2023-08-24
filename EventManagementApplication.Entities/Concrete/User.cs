using EventManagementApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public bool Status { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string ResetCode { get; set; }
        public string ResetToken { get; set; }
        public DateTime ResetTokenExpiration { get; set; }

        public ICollection<UserInvitationMapping> UserInvitationMappings { get; set; }
        public User()
        {
            RoleId = 1;
        }


    }
}
