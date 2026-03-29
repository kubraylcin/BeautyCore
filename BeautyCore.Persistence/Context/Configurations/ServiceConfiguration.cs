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
    public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            //Property: Veritabanında bir kolon oluştur ve kurallarını belirle
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(150);//Isrequired: Bu alan boş geçilemez
            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.Property(x => x.Description).HasMaxLength(500);

            // Many-to-Many: Staff <-> Service
            builder.HasMany(x => x.Staffs)
                .WithMany(x => x.Services)
                .UsingEntity(j => j.ToTable("StaffServices")); // Ara tablo ismi
            //One-to-Many Bu entity’nin 1 tane Branch’i var 1 Branch → birçok Service
            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
