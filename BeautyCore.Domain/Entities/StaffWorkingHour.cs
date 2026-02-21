using BeautyCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Entities
{
    public class StaffWorkingHour : BaseEntity
    {
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } = null!;

        public DayOfWeek Day { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan ShiftEndTime { get; set; }

        // Mola saatleri (Randevu verilemeyecek zamanlar)
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
    }
}
