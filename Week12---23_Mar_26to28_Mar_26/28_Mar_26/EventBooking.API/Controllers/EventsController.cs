using AutoMapper;
using EventBooking.API.Data;
using EventBooking.API.DTOs;
using EventBooking.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Public — anyone can view events
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(_mapper.Map<List<EventDto>>(events));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return Ok(_mapper.Map<EventDto>(ev));
        }

        // Admin only — create event
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateEventDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ev = _mapper.Map<Event>(dto);
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = ev.Id }, _mapper.Map<EventDto>(ev));
        }

        // Admin only — delete event
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Event deleted successfully" });
        }
    }
}