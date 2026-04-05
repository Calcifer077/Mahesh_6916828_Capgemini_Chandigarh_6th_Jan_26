using AutoMapper;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _repo;
    private readonly IAppointmentRepository _appointmentRepo;
    private readonly IDoctorRepository _doctorRepo;
    private readonly IMapper _mapper;
    private readonly ILogger<BillService> _logger;

    public BillService(
        IBillRepository repo,
        IAppointmentRepository appointmentRepo,
        IDoctorRepository doctorRepo,
        IMapper mapper,
        ILogger<BillService> logger
    )
    {
        _repo = repo;
        _appointmentRepo = appointmentRepo;
        _doctorRepo = doctorRepo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BillDTO?> GetByAppointmentIdAsync(int appointmentId)
    {
        var bill = await _repo.GetByAppointmentIdAsync(appointmentId);
        return bill == null ? null : _mapper.Map<BillDTO>(bill);
    }

    public async Task<BillDTO> CreateAsync(int appointmentId, decimal medicineCharges)
    {
        var appointment =
            await _appointmentRepo.GetByIdAsync(appointmentId)
            ?? throw new KeyNotFoundException($"Appointment {appointmentId} not found");

        var doctor =
            await _doctorRepo.GetByIdAsync(appointment.DoctorId)
            ?? throw new KeyNotFoundException($"Doctor {appointment.DoctorId} not found");

        var bill = new Bill
        {
            AppointmentId = appointmentId,
            ConsultationFee = doctor.ConsultationFee,
            MedicineCharges = medicineCharges,
            TotalAmount = doctor.ConsultationFee + medicineCharges,
            PaymentStatus = "Unpaid",
            CreatedAt = DateTime.UtcNow,
        };

        await _repo.AddAsync(bill);
        await _repo.SaveAsync();

        _logger.LogInformation(
            "Bill created for AppointmentId: {AppointmentId}, Total: {Total}",
            appointmentId,
            bill.TotalAmount
        );

        return _mapper.Map<BillDTO>(bill);
    }

    public async Task<BillDTO> MarkAsPaidAsync(int billId)
    {
        var bill =
            await _repo.GetByIdAsync(billId)
            ?? throw new KeyNotFoundException($"Bill {billId} not found");

        if (bill.PaymentStatus == "Paid")
            throw new InvalidOperationException("Bill is already paid");

        bill.PaymentStatus = "Paid";
        bill.PaidAt = DateTime.UtcNow;
        _repo.Update(bill);
        await _repo.SaveAsync();

        _logger.LogInformation("Bill {BillId} marked as Paid", billId);

        return _mapper.Map<BillDTO>(bill);
    }
}
