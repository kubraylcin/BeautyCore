using BeautyCore.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace BeautyCore.Domain.Entities.Identity
{
    public sealed class AppRole : IdentityRole<Guid>, IAudit, ISoftDelete
    {
        public string? Description { get; set; }

        // Audit Properties
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; private set; }

        public DateTime? LastModifiedAtUtc { get; private set; }
        public Guid? LastModifiedBy { get; private set; }

        // Soft delete Properties
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAtUtc { get; private set; }
        public Guid? DeletedBy { get; private set; }

        // IAudit Implementation (İsimler SetCreated/SetModified olarak güncellendi)
        public void SetCreated(Guid? userId)
        {
            CreatedBy = userId;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public void SetModified(Guid? userId)
        {
            LastModifiedBy = userId;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        // ISoftDelete Implementation
        public void SoftDelete(Guid? userId)
        {
            if (IsDeleted) return;

            IsDeleted = true;
            DeletedBy = userId;
            DeletedAtUtc = DateTime.UtcNow;
        }

        public void Restore()
        {
            if (!IsDeleted) return;

            IsDeleted = false;
            DeletedBy = null;
            DeletedAtUtc = null;
        }
    }
}
