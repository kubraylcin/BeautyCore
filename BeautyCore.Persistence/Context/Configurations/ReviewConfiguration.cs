using BeautyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Persistence.Context.Configurations
{
    public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.Property(x => x.Comment).HasMaxLength(500);
            builder.Property(x => x.Rating).IsRequired();

            // Çift cascade path hatasını önlemek için Restrict
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Appointment)
                .WithOne(a => a.Review)
                .HasForeignKey<Review>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
