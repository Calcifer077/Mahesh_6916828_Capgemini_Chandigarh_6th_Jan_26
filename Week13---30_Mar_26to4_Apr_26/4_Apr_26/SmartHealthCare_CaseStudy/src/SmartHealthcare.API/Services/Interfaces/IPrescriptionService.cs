using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Services.Interfaces;

public interface IPrescriptionService
{
    Task<PrescriptionDTO?> GetByAppointmentIdAsync(int appointmentId);
    Task<PrescriptionDTO> CreateAsync(CreatePrescriptionDTO dto);

    Task<PrescriptionResponseDTO> CreateSuggestionAsync(CreatePrescriptionDTO dto); // sets Status = "Suggested"

    // Task<PrescriptionResponseDTO> FinalizeAsync(int prescriptionId); // sets Status = "Finalized"

    Task<PrescriptionResponseDTO> FinalizeAsync(FinalizePrescriptionDTO dto);
}
