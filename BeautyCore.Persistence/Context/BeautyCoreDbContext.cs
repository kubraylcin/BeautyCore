using BeautyCore.Domain.Common;
using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Entities.Identity;
using BeautyCore.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BeautyCore.Persistence.Context
{
    public sealed class BeautyCoreDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IApplicationDbContext
    {
        public BeautyCoreDbContext(DbContextOptions<BeautyCoreDbContext> options) : base(options) { }

        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Staff> Staffs => Set<Staff>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<StaffWorkingHour> StaffWorkingHours => Set<StaffWorkingHour>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Promotion> Promotions => Set<Promotion>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<ImageFile> ImageFiles => Set<ImageFile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BeautyCoreDbContext).Assembly);

            // ✅ SQL Server "multiple cascade paths" hatası için: tüm FK'lerde cascade kapat
            foreach (var fk in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                // Sadece varsayılan olarak "Cascade" gelenleri Restrict yap.
                // Benim özel olarak "SetNull" dediklerime DOKUNMA.
                if (fk.DeleteBehavior == DeleteBehavior.Cascade)
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict; // veya NoAction
                }
                    
            }

            // ✅ Soft delete filter (senin mevcut loop burada kalabilir)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(CreateIsDeletedFilter(entityType.ClrType));
                }
            }
        }

        private static LambdaExpression CreateIsDeletedFilter(Type clrType)
        {
            var param = Expression.Parameter(clrType, "e");
            var prop = Expression.Property(param, nameof(ISoftDelete.IsDeleted));
            var body = Expression.Equal(prop, Expression.Constant(false));
            return Expression.Lambda(body, param);
        }

        public override int SaveChanges()
        {
            ApplyAuditAndSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditAndSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditAndSoftDelete()
        {
            Guid? userId = null; // JWT ekleyince buraya current userId gelecek

            foreach (var entry in ChangeTracker.Entries())
            {
                // 1. YENİ KAYIT EKLEME
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is IAudit audit)
                    {
                        audit.SetCreated(userId);
                    }

                    // EN KRİTİK NOKTA: Yeni kaydın silinmiş olma ihtimalini sıfırlıyoruz
                    if (entry.Entity is BaseEntity baseEnt)
                    {
                        baseEnt.Restore(); // IsDeleted'ı false yapar
                    }
                }

                // 2. GÜNCELLEME
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is IAudit audit)
                    {
                        audit.SetModified(userId);
                    }
                }

                // 3. SİLME (SOFT DELETE)
                else if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete sd)
                {
                    // Silme komutunu güncelleme komutuna çeviriyoruz
                    entry.State = EntityState.Modified;
                    sd.SoftDelete(userId);
                }
            }
        }
    }
}
