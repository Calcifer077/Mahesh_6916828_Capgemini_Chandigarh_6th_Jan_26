using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week10Assessment.Data;
using Week10Assessment.Models.ViewModels;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly Week10AssessmentContext _context;

        public ProjectsController(Week10AssessmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);

            if (project == null) return NotFound();

            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Title,Description,StartDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var project = await _context.Project.FindAsync(id);
            if (project == null) return NotFound();

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Title,Description,StartDate")] Project project)
        {
            if (id != project.ProjectId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);

            if (project == null) return NotFound();

            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }

        public async Task<IActionResult> Dashboard()
        {
            var projects = await _context.Project
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                        .ThenInclude(e => e!.Department)
                .AsNoTracking()
                .OrderBy(p => p.Title)
                .Select(p => new ProjectDashboardViewModel
                {
                    ProjectId = p.ProjectId,
                    Title = p.Title,
                    StartDate = p.StartDate,

                    AssignedEmployees = p.EmployeeProjects
                        .Select(ep => new EmployeeInfo
                        {
                            FullName = ep.Employee!.FullName,
                            Email = ep.Employee.Email,
                            DepartmentName = ep.Employee.Department!.Name,
                            AssignedDate = ep.AssignedDate
                        })
                        .OrderBy(e => e.FullName)
                        .ToList()
                })
                .ToListAsync();

            return View(projects);
        }
    }
}