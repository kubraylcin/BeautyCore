using BeautyCore.Domain.Common;
using BeautyCore.Domain.Entities.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class Branch: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } =string.Empty;

        public ICollection<Staff> StaffMembers { get; set; } = new List<Staff>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        // Eğer promosyonlar şube bazlıysa:
        public ICollection<Promotion> BranchPromotions { get; set; } = new List<Promotion>();
        //Many-to-Many
        public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }
}
