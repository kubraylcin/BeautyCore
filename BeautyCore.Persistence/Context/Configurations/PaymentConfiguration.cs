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
    public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Paynets");
            builder.Property(x=>x.Amount).HasPrecision(18,2);//Bu decimal veri tipi içindir.
            builder.Property(x => x.Currency).HasMaxLength(3).HasDefaultValue("TRY");//String alanın max uzunluğunu belirler.
            builder.Property(x => x.TransactionReference).HasMaxLength(100);

            builder.HasOne(x=>x.Appointment)//Payment → 1 tane Appointment’a bağlı
                .WithOne(a=>a.Payment).//Appointment → 1 tane Payment’a bağlı
                HasForeignKey<Payment>(x=>x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);//Ana kayıt silinemez eğer bağlı veri varsa
        }
    }
}
