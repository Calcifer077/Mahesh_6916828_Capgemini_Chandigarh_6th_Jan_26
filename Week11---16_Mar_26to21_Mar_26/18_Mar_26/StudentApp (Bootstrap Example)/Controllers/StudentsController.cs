using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentAppContext _context;

        public StudentsController(StudentAppContext context)
        {
            _context = context;
        }

        // ===================== INDEX =====================
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // ===================== CREATE =====================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // ===================== EDIT (MODAL GET) =====================
        // Returns Partial View for Modal
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
                return NotFound();

            return PartialView("_EditModal", student);
        }

        // ===================== EDIT (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Student.Any(e => e.Id == student.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return PartialView("_EditModal", student);
        }

        // ===================== DELETE (MODAL POST) =====================
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student != null)
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // ===================== OPTIONAL: DETAILS =====================
        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}