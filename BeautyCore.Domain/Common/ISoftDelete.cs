using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Common
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        DateTime? DeletedAtUtc { get; }
        Guid? DeletedBy { get; }
        void SoftDelete(Guid? userId);
        void Restore();
    }
}


