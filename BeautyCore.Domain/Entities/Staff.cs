using BeautyCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class Staff:BaseEntity
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } =string.Empty;
        public Guid? ProfilePictureId { get; set; }
        public ImageFile? ProfilePicture { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<StaffWorkingHour> WorkingHours { get; set; } = new List<StaffWorkingHour>();

    }
}
