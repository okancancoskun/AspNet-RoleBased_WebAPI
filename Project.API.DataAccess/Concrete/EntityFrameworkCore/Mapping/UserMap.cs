using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Email);
            builder.Property(I => I.Username);
            builder.Property(I => I.Password);

            builder.HasOne(I => I.Role).WithMany().HasForeignKey(I => I.RoleId);
        }
    }
}
