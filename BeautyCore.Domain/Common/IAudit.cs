using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Common
{
    public interface IAudit
    {
        DateTime CreatedAtUtc { get; }
        Guid? CreatedBy { get; }
        DateTime? LastModifiedAtUtc { get; }
        Guid? LastModifiedBy { get; }
        void SetCreated(Guid? userId);
        void SetModified(Guid? userId);
    }
}
