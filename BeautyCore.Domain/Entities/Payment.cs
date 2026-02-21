using BeautyCore.Domain.Common;
using BeautyCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

        public decimal Amount { get; set; }
        public string Currency { get; set; } = "TRY";
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public PaymentMethod Method { get; set; } // Enum: Cash, CreditCard, etc.
        public string? TransactionReference { get; set; }
    }
}
