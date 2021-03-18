using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name);
            builder.Property(I => I.Description);

            builder.HasOne(I => I.Category).WithMany().HasForeignKey(I => I.CategoryId);

            builder.HasOne(I => I.Author).WithMany().HasForeignKey(I => I.AuthorId);
        }
    }
}
