using EventManagementApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.DataAccess.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Type).IsRequired().HasMaxLength(150);
            builder.Property(x => x.StartTime).IsRequired().HasMaxLength(10);
            builder.Property(x => x.EndTime).IsRequired().HasMaxLength(10);
        }
    }
}




