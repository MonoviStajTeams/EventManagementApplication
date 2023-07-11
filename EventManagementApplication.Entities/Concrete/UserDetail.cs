using EventManagementApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.Concrete
{
    public class UserDetail:BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string? ProfileImagePath { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
