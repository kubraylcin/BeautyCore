using BeautyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Persistence.Context.Configurations
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(x=>x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.PhoneNumber).HasMaxLength(20);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x=>x.Branch)
                .WithMany(x=>x.Customers)
                .HasForeignKey(x=>x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
