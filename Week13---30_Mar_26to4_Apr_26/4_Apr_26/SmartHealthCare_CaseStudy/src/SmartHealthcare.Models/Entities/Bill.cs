using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Models.Entities;

public class Bill
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }

    [Range(0, 100000)]
    public decimal ConsultationFee { get; set; }

    [Range(0, 100000)]
    public decimal MedicineCharges { get; set; }

    [Range(0, 200000)]
    public decimal TotalAmount { get; set; }

    [Required, MaxLength(20)]
    public string PaymentStatus { get; set; } = "Unpaid";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PaidAt { get; set; }

    public Appointment Appointment { get; set; } = null!;
}
