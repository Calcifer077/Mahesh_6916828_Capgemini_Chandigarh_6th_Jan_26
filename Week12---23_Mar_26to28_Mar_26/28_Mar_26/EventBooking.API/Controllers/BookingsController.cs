using AutoMapper;
using EventBooking.API.Data;
using EventBooking.API.DTOs;
using EventBooking.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // User — their own bookings only
        [HttpGet]
        public async Task<IActionResult> GetMyBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookings = await _context.Bookings
                .Include(b => b.Event)
                .Where(b => b.UserId == userId)
                .ToListAsync();

            return Ok(_mapper.Map<List<BookingDto>>(bookings));
        }

        // Admin — view all bookings across all users
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Event)
                .ToListAsync();

            return Ok(_mapper.Map<List<BookingDto>>(bookings));
        }

        // Any logged-in user — book tickets
        [HttpPost]
        public async Task<IActionResult> Book(CreateBookingDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ev = await _context.Events.FindAsync(dto.EventId);

            if (ev == null) return NotFound(new { message = "Event not found" });
            if (ev.AvailableSeats < dto.SeatsBooked)
                return BadRequest(new { message = $"Only {ev.AvailableSeats} seats available" });

            ev.AvailableSeats -= dto.SeatsBooked;

            var booking = new Booking
            {
                EventId = dto.EventId,
                UserId = userId!,
                SeatsBooked = dto.SeatsBooked
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            await _context.Entry(booking).Reference(b => b.Event).LoadAsync();
            return CreatedAtAction(nameof(GetMyBookings), _mapper.Map<BookingDto>(booking));
        }

        // User — cancel their own booking
        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var booking = await _context.Bookings
                .Include(b => b.Event)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (booking == null) return NotFound(new { message = "Booking not found" });

            booking.Event.AvailableSeats += booking.SeatsBooked;
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Booking cancelled successfully" });
        }
    }
}