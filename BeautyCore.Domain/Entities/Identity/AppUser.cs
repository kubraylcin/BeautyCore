using BeautyCore.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace BeautyCore.Domain.Entities.Identity
{
    public sealed class AppUser : IdentityUser<Guid>, IAudit, ISoftDelete
    {
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        // Profil
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Refresh token
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        // Audit
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; private set; }

        public DateTime? LastModifiedAtUtc { get; private set; }
        public Guid? LastModifiedBy { get; private set; }

        // Soft delete
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAtUtc { get; private set; }
        public Guid? DeletedBy { get; private set; }

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

        public void SoftDelete(Guid? userId)
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
