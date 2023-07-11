using EventManagementApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.Concrete
{
    public class Invitation:BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
