using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Instrutorcasestudy.Data;
using Instrutorcasestudy.Models;

namespace Instrutorcasestudy.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public IActionResult Index()
        {
            var instructors = _context.Instructors.ToList();
            return View(instructors);
        }

        // GET: Instructors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var instructor = _context.Instructors.FirstOrDefault(m => m.InstructorId == id);
            if (instructor == null) return NotFound();

            return View(instructor);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null) return NotFound();

            return View(instructor);
        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Instructor instructor)
        {
            if (id != instructor.InstructorId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Instructors.Any(e => e.InstructorId == instructor.InstructorId))
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
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var instructor = _context.Instructors.FirstOrDefault(m => m.InstructorId == id);
            if (instructor == null) return NotFound();

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int instructorId)
        {
            var instructor = _context.Instructors.Find(instructorId);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}