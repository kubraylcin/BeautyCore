using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Commands.SetWorkingHours
{
    public record WorkingHourDto(
    DayOfWeek Day,
    TimeSpan ShiftStartTime,
    TimeSpan ShiftEndTime,
    TimeSpan? BreakStartTime,
    TimeSpan? BreakEndTime);

    public record SetStaffWorkingHoursCommand(
        Guid StaffId,
        List<WorkingHourDto> WorkingHours) : IRequest<bool>;
}
