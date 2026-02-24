using BeautyCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class Service: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
        // Many-to-many
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
        // Bu hizmetin randevuları
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
