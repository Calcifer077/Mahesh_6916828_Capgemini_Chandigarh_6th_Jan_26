using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Students.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var student = await _context.Students.FindAsync(id);
        return PartialView("_StudentModal", student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}