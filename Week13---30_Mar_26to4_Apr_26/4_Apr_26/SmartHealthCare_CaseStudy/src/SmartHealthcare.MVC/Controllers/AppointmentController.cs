using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.MVC.Services;

namespace SmartHealthcare.MVC.Controllers;

public class AppointmentController : Controller
{
    private readonly IApiService _apiService;
    private readonly ILogger<AppointmentController> _logger;

    public AppointmentController(IApiService apiService, ILogger<AppointmentController> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        var role = HttpContext.Session.GetString("Role");
        PagedResult<AppointmentDTO>? result = null;

        if (role == "Patient")
        {
            result = await _apiService.GetAsync<PagedResult<AppointmentDTO>>(
                "appointments/my-appointments?pageNumber=1&pageSize=50",
                token
            );
        }
        else if (role == "Doctor")
        {
            result = await _apiService.GetAsync<PagedResult<AppointmentDTO>>(
                "appointments/doctor-appointments?pageNumber=1&pageSize=50",
                token
            );
        }
        else if (role == "Admin")
        {
            result = await _apiService.GetAsync<PagedResult<AppointmentDTO>>(
                "appointments?pageNumber=1&pageSize=50",
                token
            );
        }

        ViewBag.Role = role;
        return View(result?.Items ?? Enumerable.Empty<AppointmentDTO>());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        // Fetch all available doctors with pagination
        var doctorsResult = await _apiService.GetAsync<PagedResult<DoctorDTO>>(
            "doctors?pageNumber=1&pageSize=100",
            token
        );
        ViewBag.Doctors = doctorsResult?.Items ?? Enumerable.Empty<DoctorDTO>();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAppointmentDTO dto)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        if (!ModelState.IsValid)
        {
            var doctorsResult = await _apiService.GetAsync<PagedResult<DoctorDTO>>(
                "doctors?pageNumber=1&pageSize=100",
                token
            );
            ViewBag.Doctors = doctorsResult?.Items ?? Enumerable.Empty<DoctorDTO>();
            return View(dto);
        }

        try
        {
            var result = await _apiService.PostAsync<AppointmentDTO>("appointments", dto, token);
            if (result == null)
            {
                TempData["Error"] =
                    "Failed to create appointment. Please ensure your patient profile is set up and all fields are valid.";
                var doctorsResult = await _apiService.GetAsync<PagedResult<DoctorDTO>>(
                    "doctors?pageNumber=1&pageSize=100",
                    token
                );
                ViewBag.Doctors = doctorsResult?.Items ?? Enumerable.Empty<DoctorDTO>();
                return View(dto);
            }

            _logger.LogInformation(
                $"Appointment {result.Id} booked successfully for doctor {result.DoctorId}"
            );
            TempData["Success"] =
                "Appointment booked successfully! You will be able to see it in your appointments list.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating appointment");
            TempData["Error"] =
                "An error occurred while booking the appointment. Please try again.";
            var doctorsResult = await _apiService.GetAsync<PagedResult<DoctorDTO>>(
                "doctors?pageNumber=1&pageSize=100",
                token
            );
            ViewBag.Doctors = doctorsResult?.Items ?? Enumerable.Empty<DoctorDTO>();
            return View(dto);
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
            return RedirectToAction("Login", "Account");

        var appointment = await _apiService.GetAsync<AppointmentDTO>($"appointments/{id}", token);
        if (appointment == null)
            return NotFound();

        ViewBag.Role = HttpContext.Session.GetString("Role");
        ViewBag.Prescription = await _apiService.GetAsync<PrescriptionDTO>(
            $"prescriptions/appointment/{id}",
            token
        );
        ViewBag.Bill = await _apiService.GetAsync<BillDTO>($"bills/appointment/{id}", token); // ADD
        return View(appointment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SuggestPrescription(
        [FromForm] int appointmentId,
        [FromForm] CreatePrescriptionDTO dto
    )
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
            return RedirectToAction("Login", "Account");

        dto.AppointmentId = appointmentId;

        try
        {
            var result = await _apiService.PostAsync<PrescriptionResponseDTO>(
                "prescriptions/suggest",
                dto,
                token
            );

            _logger.LogInformation("Something" + result);

            if (result == null)
                TempData["Error"] = "Failed to create prescription suggestion.";
            else
                TempData["Success"] = "Prescription suggestion created successfully.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating prescription suggestion");
            TempData["Error"] = "An error occurred while creating the suggestion.";
        }

        return RedirectToAction(nameof(Details), new { id = appointmentId });
    }

    // ADD this action
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> FinalizePrescription(
        [FromForm] int prescriptionId,
        [FromForm] int appointmentId,
        [FromForm] decimal medicineCharges
    )
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
            return RedirectToAction("Login", "Account");

        try
        {
            var body = new { MedicineCharges = medicineCharges };
            var result = await _apiService.PatchAsync<PrescriptionResponseDTO>(
                $"prescriptions/{prescriptionId}/finalize",
                body,
                token
            );

            if (result == null)
                TempData["Error"] = "Failed to finalize prescription.";
            else
                TempData["Success"] = "Prescription finalized and bill generated.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error finalizing prescription");
            TempData["Error"] = "An error occurred while finalizing the prescription.";
        }

        return RedirectToAction(nameof(Details), new { id = appointmentId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PayBill([FromForm] int billId, [FromForm] int appointmentId)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
            return RedirectToAction("Login", "Account");

        try
        {
            var result = await _apiService.PatchAsync<BillDTO>($"bills/{billId}/pay", null, token);
            if (result == null)
                TempData["Error"] = "Failed to process payment.";
            else
                TempData["Success"] = "Payment successful!";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing payment");
            TempData["Error"] = "An error occurred while processing payment.";
        }

        return RedirectToAction(nameof(Details), new { id = appointmentId });
    }
}
