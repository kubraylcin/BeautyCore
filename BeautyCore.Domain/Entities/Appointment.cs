using BeautyCore.Domain.Common;
using BeautyCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime StartAtUtc { get; set; }
        public DateTime EndAtUtc { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string? Note { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } = null!;

        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        public Payment? Payment { get; set; } // Bir randevunun bir ödemesi olur
        public Review? Review { get; set; }   // Bir randevuya bir yorum yapılır

        // Eğer randevuda promosyon kullanıldıysa:
        public Guid? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
    }
}
