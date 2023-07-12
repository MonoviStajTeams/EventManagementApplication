using EventManagementApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Concrete
{
    public class EventManagementDbContext : DbContext
    {

        public DbSet<Event> Events { get; set; }
    }
}
