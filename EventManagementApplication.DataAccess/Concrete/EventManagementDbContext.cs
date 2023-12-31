﻿using EventManagementApplication.DataAccess.Configurations;
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

        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options) : base(options)
        {

        }

        public EventManagementDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserDetailConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserInvitationMapping> UserInvitationMappings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { set; get; }
        public DbSet<Invitation> Invitations { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<Log> Logs { set; get; }
        public DbSet<OperationClaim> OperationClaims { set; get; }
        public DbSet<UserOperationClaim> UserOperationClaims { set; get; }
    }
}
