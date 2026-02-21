using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        // Audit
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public string? CreatedBy { get; private set; }

        public DateTime? LastModifiedAtUtc { get; private set; }
        public string? LastModifiedBy { get; private set; }

        // Soft delete
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAtUtc { get; private set; }
        public string? DeletedBy { get; private set; }

        // Domain methods (setter yerine kontrollü güncelleme)
        public void SetCreated(string? userId)
        {
            CreatedBy = userId;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public void SetModified(string? userId)
        {
            LastModifiedBy = userId;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void SoftDelete(string? userId)
        {
            if (IsDeleted) return;

            IsDeleted = true;
            DeletedBy = userId;
            DeletedAtUtc = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedBy = null;
            DeletedAtUtc = null;
        }
    }
}
