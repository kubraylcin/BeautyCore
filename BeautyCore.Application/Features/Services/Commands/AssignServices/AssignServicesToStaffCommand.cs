using MediatR;

namespace BeautyCore.Application.Features.Staff.Commands.AssignServices;

// Hangi personele (StaffId), hangi hizmetleri (ServiceIds) atıyoruz?
public record AssignServicesToStaffCommand(
    Guid StaffId,
    List<Guid> ServiceIds) : IRequest<bool>;
