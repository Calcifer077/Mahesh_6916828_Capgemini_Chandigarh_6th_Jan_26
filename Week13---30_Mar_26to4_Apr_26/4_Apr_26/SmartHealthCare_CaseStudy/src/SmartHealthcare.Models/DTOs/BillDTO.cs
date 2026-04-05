using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Models.DTOs;

public class BillDTO
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? PaidAt { get; set; }
}

public class FinalizePrescriptionDTO
{
    [Required]
    public int PrescriptionId { get; set; }

    [Required, Range(0, 100000)]
    public decimal MedicineCharges { get; set; }
}
