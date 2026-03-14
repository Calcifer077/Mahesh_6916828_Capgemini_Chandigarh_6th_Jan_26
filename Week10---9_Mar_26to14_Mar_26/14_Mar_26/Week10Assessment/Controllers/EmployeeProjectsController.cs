using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week10Assessment.Data;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private readonly Week10AssessmentContext _context;

        public EmployeeProjectsController(Week10AssessmentContext context)
        {
            _context = context;
        }

        // GET: EmployeeProjects
        public async Task<IActionResult> Index()
        {
            var week10AssessmentContext = _context.EmployeeProject.Include(e => e.Employee).Include(e => e.Project);
            return View(await week10AssessmentContext.ToListAsync());
        }

        // GET: EmployeeProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProject = await _context.EmployeeProject
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeProject == null)
            {
                return NotFound();
            }

            return View(employeeProject);
        }

        // GET: EmployeeProjects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email");
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Title");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,ProjectId,AssignedDate")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email", employeeProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Title", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProject = await _context.EmployeeProject.FindAsync(id);
            if (employeeProject == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email", employeeProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Title", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ProjectId,AssignedDate")] EmployeeProject employeeProject)
        {
            if (id != employeeProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeProjectExists(employeeProject.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email", employeeProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Title", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProject = await _context.EmployeeProject
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeProject == null)
            {
                return NotFound();
            }

            return View(employeeProject);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeProject = await _context.EmployeeProject.FindAsync(id);
            if (employeeProject != null)
            {
                _context.EmployeeProject.Remove(employeeProject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeProjectExists(int id)
        {
            return _context.EmployeeProject.Any(e => e.Id == id);
        }
    }
}
