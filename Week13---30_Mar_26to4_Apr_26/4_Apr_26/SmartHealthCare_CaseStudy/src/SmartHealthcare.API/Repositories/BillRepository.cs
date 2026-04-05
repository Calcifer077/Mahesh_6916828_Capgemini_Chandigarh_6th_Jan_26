using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    public BillRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<Bill?> GetByAppointmentIdAsync(int appointmentId) =>
        await _dbSet.FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);

    public async Task<Bill?> GetByIdAsync(int id) =>
        await _dbSet.FirstOrDefaultAsync(b => b.Id == id);
}
