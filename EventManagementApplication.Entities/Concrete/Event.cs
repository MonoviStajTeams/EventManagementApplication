using EventManagementApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Entities.Concrete
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubContent { get; set; }
        public DateTime Date { get; set; }

        public string Type { get; set; }
        public bool Status { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
