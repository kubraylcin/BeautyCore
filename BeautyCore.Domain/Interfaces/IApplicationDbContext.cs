using BeautyCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Branch> Branches { get; }
        DbSet<Staff> Staffs { get; }
        DbSet<Service> Services { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Appointment> Appointments { get; }
        DbSet<Payment> Payments { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<StaffWorkingHour> StaffWorkingHours { get; }
    }
}
