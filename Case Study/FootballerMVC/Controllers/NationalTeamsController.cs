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
    public class NationalTeamsController : Controller
    {
        private readonly FootballerMVCContext _context;

        public NationalTeamsController(FootballerMVCContext context)
        {
            _context = context;
        }

        // GET: NationalTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.NationalTeam.ToListAsync());
        }

        // GET: NationalTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationalTeam = await _context.NationalTeam
                .FirstOrDefaultAsync(m => m.NationalTeamId == id);
            if (nationalTeam == null)
            {
                return NotFound();
            }

            return View(nationalTeam);
        }

        // GET: NationalTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NationalTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalTeamId,TeamName,Country,Confederation,HeadCoach,FIFA_Ranking")] NationalTeam nationalTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationalTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationalTeam);
        }

        // GET: NationalTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationalTeam = await _context.NationalTeam.FindAsync(id);
            if (nationalTeam == null)
            {
                return NotFound();
            }
            return View(nationalTeam);
        }

        // POST: NationalTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NationalTeamId,TeamName,Country,Confederation,HeadCoach,FIFA_Ranking")] NationalTeam nationalTeam)
        {
            if (id != nationalTeam.NationalTeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationalTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalTeamExists(nationalTeam.NationalTeamId))
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
            return View(nationalTeam);
        }

        // GET: NationalTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationalTeam = await _context.NationalTeam
                .FirstOrDefaultAsync(m => m.NationalTeamId == id);
            if (nationalTeam == null)
            {
                return NotFound();
            }

            return View(nationalTeam);
        }

        // POST: NationalTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nationalTeam = await _context.NationalTeam.FindAsync(id);
            if (nationalTeam != null)
            {
                _context.NationalTeam.Remove(nationalTeam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalTeamExists(int id)
        {
            return _context.NationalTeam.Any(e => e.NationalTeamId == id);
        }
    }
}
