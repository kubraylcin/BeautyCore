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
    public sealed class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("StaffMembers");
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(100);

            //branch ile ilişkisi
            builder.HasOne(x=>x.Branch).WithMany(x => x.StaffMembers).HasForeignKey(x=>x.BranchId).OnDelete(DeleteBehavior.Restrict);//// Şube silinirse personeller silinmesin
            // Çalışma Saatleri (Cascade mantıklı çünkü personel giderse saatleri anlamsız kalır)
            builder.HasMany(x=>x.WorkingHours)
                .WithOne(x=>x.Staff)
                .HasForeignKey(x=>x.StaffId)
                .OnDelete(DeleteBehavior.Cascade);//Ana kayıt silinince bağlı kayıt da silinir

        }
    }
}
