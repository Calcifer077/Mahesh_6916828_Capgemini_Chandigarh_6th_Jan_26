using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballerMVC.Data;
using FootballerMVC.Models;

namespace FootballerMVC.Controllers
{
    public class FootballersController : Controller
    {
        private readonly FootballerMVCContext _context;

        public FootballersController(FootballerMVCContext context)
        {
            _context = context;
        }

        // GET: Footballers
        public async Task<IActionResult> Index()
        {
            var footballerMVCContext = _context.Footballer.Include(f => f.Club).Include(f => f.NationalTeam);
            return View(await footballerMVCContext.ToListAsync());
        }

        // GET: Footballers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballer
                .Include(f => f.Club)
                .Include(f => f.NationalTeam)
                .FirstOrDefaultAsync(m => m.FootballerId == id);
            if (footballer == null)
            {
                return NotFound();
            }

            return View(footballer);
        }

        // GET: Footballers/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Club, "ClubId", "ClubName");
            ViewData["NationalTeamId"] = new SelectList(_context.Set<NationalTeam>(), "NationalTeamId", "TeamName");
            return View();
        }

        // POST: Footballers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FootballerId,Name,Age,Position,JerseyNumber,Nationality,Goals,Assists,Appearances,MarketValue,DateOfBirth,ClubId,NationalTeamId")] Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "ClubId", "ClubName", footballer.ClubId);
            ViewData["NationalTeamId"] = new SelectList(_context.Set<NationalTeam>(), "NationalTeamId", "TeamName", footballer.NationalTeamId);
            return View(footballer);
        }

        // GET: Footballers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballer.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "ClubId", "ClubName", footballer.ClubId);
            ViewData["NationalTeamId"] = new SelectList(_context.Set<NationalTeam>(), "NationalTeamId", "TeamName", footballer.NationalTeamId);
            return View(footballer);
        }

        // POST: Footballers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FootballerId,Name,Age,Position,JerseyNumber,Nationality,Goals,Assists,Appearances,MarketValue,DateOfBirth,ClubId,NationalTeamId")] Footballer footballer)
        {
            if (id != footballer.FootballerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballerExists(footballer.FootballerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "ClubId", "ClubName", footballer.ClubId);
            ViewData["NationalTeamId"] = new SelectList(_context.Set<NationalTeam>(), "NationalTeamId", "TeamName", footballer.NationalTeamId);
            return View(footballer);
        }

        // GET: Footballers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballer = await _context.Footballer
                .Include(f => f.Club)
                .Include(f => f.NationalTeam)
                .FirstOrDefaultAsync(m => m.FootballerId == id);
            if (footballer == null)
            {
                return NotFound();
            }

            return View(footballer);
        }

        // POST: Footballers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footballer = await _context.Footballer.FindAsync(id);
            if (footballer != null)
            {
                _context.Footballer.Remove(footballer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballerExists(int id)
        {
            return _context.Footballer.Any(e => e.FootballerId == id);
        }
    }
}
