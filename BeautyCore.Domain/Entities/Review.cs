using BeautyCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

        public int Rating { get; set; } // 1-5 arası yıldız
        public string? Comment { get; set; }
    }
}
