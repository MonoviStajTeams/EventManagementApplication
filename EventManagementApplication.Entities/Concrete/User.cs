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
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public int RoleId { get; set; }
        public Role Role { get; set; }





    }
}
