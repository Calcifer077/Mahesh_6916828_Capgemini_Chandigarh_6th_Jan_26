using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Services.Interfaces;

public interface IBillService
{
    Task<BillDTO?> GetByAppointmentIdAsync(int appointmentId);
    Task<BillDTO> CreateAsync(int appointmentId, decimal medicineCharges);
    Task<BillDTO> MarkAsPaidAsync(int billId);
}
