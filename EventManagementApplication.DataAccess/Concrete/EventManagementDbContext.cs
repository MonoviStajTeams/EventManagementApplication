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


        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserInvitationMapping> UserInvitationMappings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Event> Events { get; set; }


        public DbSet<User> Users { set; get; }

        public DbSet<Invitation> Invitations { set; get; }

        public DbSet<Notification> Notifications { set; get; }
    }
}
