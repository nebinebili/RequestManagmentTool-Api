using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using System.Reflection.Emit;

namespace DataAccess.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.FirstName).HasMaxLength(20);
            builder.Property(u => u.LastName).HasMaxLength(20);
            builder.Property(u=> u.Position).HasMaxLength(100);
            builder.Property(u=>u.Department).HasMaxLength(100);
            builder.Property(u=>u.InnerPhone).HasMaxLength(20);
            builder.Property(u=>u.MobilPhone).HasMaxLength(20); 
            builder.Property(u=>u.Password).HasMaxLength(20);
            builder.Property(u=>u.NotificationPermission).HasDefaultValue(true);
            builder.Property(u=>u.IsActive).HasDefaultValue(true);
            builder.Property(u=>u.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
